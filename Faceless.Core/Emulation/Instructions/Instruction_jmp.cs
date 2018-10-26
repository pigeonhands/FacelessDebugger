using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_jmp : FacelessInstruction {
        public Instruction_jmp() : base(Code.Jmp) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            var targetInstruction = (Instruction)i.Operand;
            emulator.CurrentCall.GotoInstruction(targetInstruction);
        }
    }
}
