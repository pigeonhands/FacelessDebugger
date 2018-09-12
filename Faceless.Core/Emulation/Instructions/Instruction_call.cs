using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_call : FacelessInstruction {
        public Instruction_call(Code c) : base(c) {
        }

        public static void EmulateCall(MethodDef m, Emulator emulator) {
            object[] pushValues = emulator
                .MemoryStack.CurrentFrame
                .Pop(m.Parameters.Count)
                .Reverse()
                .ToArray();

            var facelessValues = new FacelessValue[pushValues.Length];
            
            for (int index = 0; index < m.Parameters.Count; index++) {
                if(pushValues[index] is FacelessValue) {
                    facelessValues[index] = (FacelessValue)pushValues[index];
                } else {
                    facelessValues[index] = new FacelessValue(pushValues[index], m.Parameters[index].Type);
                }
                
            }

            if (!emulator.ShouldCallInternal(m, facelessValues)) {
                emulator.MemoryStack.CurrentFrame.Push(null);
            }

            var call = new EmulatedCall(emulator.CurrentCall, m, facelessValues);
            emulator.MemoryStack.NewFrame();
            emulator.CurrentCall = call;
        }

        private void ReflectCall(MemberRef m, Emulator emulator) {
            var typename = m.DeclaringType.ReflectionFullName;

            object[] par = emulator.MemoryStack.CurrentFrame.Pop(m.MethodSig.Params.Count)
                .Select(x => (x is FacelessValue) ? ((FacelessValue)x).Value : x)
                .Reverse()
                .ToArray();

            if (!emulator.ShouldCallExternal(m, par)) {
                emulator.MemoryStack.CurrentFrame.Push(null);
                return;
            }

            Type declaringType = Type.GetType(m.GetDeclaringTypeFullName());

            object inst = null;
            if (m.HasThis) {
                 FacelessValue fv = (FacelessValue)emulator.MemoryStack.CurrentFrame.Pop();
                inst = fv.Value;
            }



            if (m.Name.Equals(".ctor")) {

                declaringType.GetConstructor(new Type[0]).Invoke(par);

            } else {

                MethodInfo mi = declaringType.GetMethods().First(x => string.Equals(MethodInfoToSig(x), m.FullName)); //aids but works
                object ret = mi.Invoke(inst, par);
                if (m.ReturnType != m.Module.CorLibTypes.Void) {
                    emulator.MemoryStack.CurrentFrame.Push(ret);
                }

            }
        }

        private string MethodInfoToSig(MethodInfo mi) {
            string[] param = mi.GetParameters()
                              .Select(p => p.ParameterType.FullName)
                              .ToArray();
            string paramString = string.Join(",", param);
            string sig = $"{mi.ReturnType} {mi.DeclaringType.FullName}::{mi.Name}({paramString})";
            return sig;
        }

        public override void Execute(Instruction i, Emulator emulator) {
            HandleMethodCalling(i.Operand, emulator);
        }

        private void HandleMethodCalling(object c, Emulator emulator) {
            if (c is MemberRef) {
                ReflectCall((MemberRef)c, emulator);
            } else if (c is MethodSpec) {
                HandleMethodCalling(((MethodSpec)c).Method, emulator);
            } else {
                EmulateCall((MethodDef)c, emulator);
            }
        }
    }
}
