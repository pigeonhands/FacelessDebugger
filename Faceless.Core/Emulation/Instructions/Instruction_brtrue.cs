using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_brtrue : FacelessInstruction {
        public Instruction_brtrue() : base(Code.Brtrue) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            long cond = Convert.ToInt64(emulator.MemoryStack.CurrentFrame.Pop());
            if(cond != 0) {
                emulator.CurrentCall.GotoInstruction((Instruction)i.Operand);
            }
        }
    }
}
