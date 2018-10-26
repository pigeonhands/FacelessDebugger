using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_call : FacelessInstruction {

        private string[] SkipCalls = new string[] {
                    "System.Void System.Windows.Forms.Application::SetCompatibleTextRenderingDefault(System.Boolean)"

        };

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

            if (SkipCalls.Contains(m.FullName)) {
                return;
            }

            if (!emulator.ShouldCallExternal(m, par)) {
                emulator.MemoryStack.CurrentFrame.Push(null);
                return;
            }

            object inst = null;
            if (m.HasThis) {
                 FacelessValue fv = (FacelessValue)emulator.MemoryStack.CurrentFrame.Pop();
                inst = fv.Value;
            }

            Type t = emulator.ResolveReflectiveType(m.DeclaringType);

            Type[] callParamTypes = m.MethodSig.Params.Select(x => emulator.ResolveReflectiveType(x.ToTypeDefOrRef())).ToArray();
            MethodInfo mi = t.GetMethod(m.Name, callParamTypes);

            object ret = null;
            if(mi != null) {
                ret = mi.Invoke(inst, par.Select((x, i) =>
                    callParamTypes[i] == typeof(bool) && !(x is bool)? (int)x != 0 : x).ToArray()); // 0 == False for boolean calling parameters
            }
            
            if (m.ReturnType != m.Module.CorLibTypes.Void) {
                emulator.MemoryStack.CurrentFrame.Push(ret);
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

        protected override void Handle(Instruction i, Emulator emulator) {
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
