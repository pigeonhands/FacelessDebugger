using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_nop : FacelessInstruction {
        public Instruction_nop() : base(Code.Nop) {
        }

        protected override void Handle(Instruction i, Emulator emulator) {
        }
    }
}
