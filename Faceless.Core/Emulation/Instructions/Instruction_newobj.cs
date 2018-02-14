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
            MemberRef mr = (MemberRef)i.Operand;
            Type t = Type.GetType(mr.GetDeclaringTypeFullName());

            object[] args = emulator.MemoryStack.CurrentFrame.Pop(mr.MethodSig.Params.Count).Reverse().ToArray();
            emulator.MemoryStack.CurrentFrame.Push(new FacelessValue(Activator.CreateInstance(t, args), mr.DeclaringType.ToTypeSig()));
        }
    }
}
