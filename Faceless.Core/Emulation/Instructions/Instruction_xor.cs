using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_xor : FacelessInstruction {
        public Instruction_xor() : base(Code.Xor) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            dynamic[] nums = GetStackValues(2, emulator);

            emulator.MemoryStack.CurrentFrame.Push(nums[1] ^ nums[0]);
        }
    }
}
