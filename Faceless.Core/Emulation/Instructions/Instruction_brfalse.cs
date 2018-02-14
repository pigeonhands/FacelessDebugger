using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_brfalse : FacelessInstruction {
        public Instruction_brfalse() : base(Code.Brfalse) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            dynamic val = emulator.MemoryStack.CurrentFrame.Pop();
            if(val == 0) {
                emulator.CurrentCall.GotoInstruction((Instruction)i.Operand);
            }
        }
    }
}
