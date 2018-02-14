using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ret : FacelessInstruction{
        public Instruction_ret() : base(dnlib.DotNet.Emit.Code.Ret) {
        }

        public override void Execute(Instruction i, Emulator emulator) {
            if (emulator.CurrentCall.MethodDefinition.HasReturnType) {
                object ret = emulator.MemoryStack.CurrentFrame.Pop();
                emulator.MemoryStack.PreviousFrame();
                emulator.MemoryStack.CurrentFrame.Push(ret);
            } else {
                emulator.MemoryStack.PreviousFrame();
            }
            emulator.CurrentCall = emulator.CurrentCall.ParentCall;
        }
    }
}
