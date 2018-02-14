using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ld : FacelessInstruction {
        public Instruction_ld(Code _ldcCode) : base(_ldcCode) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            emulator.MemoryStack.CurrentFrame.Push(i.Operand);
        }
    }
}
