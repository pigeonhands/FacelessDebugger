using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_add : FacelessInstruction {
        public Instruction_add() : base(dnlib.DotNet.Emit.Code.Add) {
        }

        public override void Execute(Instruction i, Emulator emulator) {
            dynamic[] nums = GetStackValues(2, emulator);
            
            emulator.MemoryStack.CurrentFrame.Push(nums[1] + nums[0]);
        }
    }
}
