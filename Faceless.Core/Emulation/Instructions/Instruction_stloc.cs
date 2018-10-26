using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_stloc : FacelessInstruction {
        public Instruction_stloc() : base(Code.Stloc) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            Local l = (Local)i.Operand;
            emulator.CurrentCall.Locals[l.Index] = emulator.MemoryStack.CurrentFrame.Pop();
        }
    }
}
