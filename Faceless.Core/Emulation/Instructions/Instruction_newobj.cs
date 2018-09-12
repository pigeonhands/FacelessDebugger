using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using dnlib.DotNet;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_newobj : FacelessInstruction {
        public Instruction_newobj() : base(Code.Newobj) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            IMethodDefOrRef mr = (IMethodDefOrRef)i.Operand;
            var typename = mr.DeclaringType.ReflectionFullName;

            object[] args = emulator.MemoryStack.CurrentFrame.Pop(mr.MethodSig.Params.Count).Reverse().ToArray();

            object instance = null;

            if(mr is MethodDef) {
                // Internal type.

                var asm = (AssemblyDef)mr.DeclaringType.DefinitionAssembly;
                if (!asm.TypeExistsReflection(typename)) {
                    throw new InvalidOperationException($"Type does not exist. ({typename}).");
                }
                TypeDef type = asm.Find(typename, true);
                instance = new FacelessObject(type);

                emulator.MemoryStack.CurrentFrame.Push(new FacelessValue(instance, mr.DeclaringType.ToTypeSig())); // newobj instance

                emulator.MemoryStack.CurrentFrame.Push(instance); //.ctor call

                Instruction_call.EmulateCall(type.FindDefaultConstructor(), emulator);
            } else {
                Type t = Type.GetType(typename, true);
                instance = Activator.CreateInstance(t, args);

                emulator.MemoryStack.CurrentFrame.Push(new FacelessValue(instance, mr.DeclaringType.ToTypeSig()));
            }

            
            
        }
    }
}
