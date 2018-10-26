using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_dup : FacelessInstruction {
        public Instruction_dup() : base(Code.Dup) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            var val = emulator.MemoryStack.CurrentFrame.Pop();
            emulator.MemoryStack.CurrentFrame.Push(val);
            emulator.MemoryStack.CurrentFrame.Push(val);
        }
    }
}
