using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_pop : FacelessInstruction {
        public Instruction_pop() : base(Code.Pop) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            emulator.MemoryStack.CurrentFrame.Pop();
        }
    }
}
