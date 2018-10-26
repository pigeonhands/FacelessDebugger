using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ldnull : FacelessInstruction {
        public Instruction_ldnull() : base(Code.Ldnull) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            emulator.MemoryStack.CurrentFrame.Push(null);
        }
    }
}
