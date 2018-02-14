using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Instructions {
    internal abstract class FacelessInstruction {

        public Code InstructionCode { get; private set; }
        public FacelessInstruction(Code _code) {
            InstructionCode = _code;
        }
        public abstract void Execute(Instruction i, Emulator emulator);

        protected dynamic[] GetStackValues(int i, Emulator emulator) {
            return emulator.MemoryStack
              .CurrentFrame.Pop(2)
              .Select(x => (x is FacelessValue) ? ((FacelessValue)x).Value : x)
              .ToArray();
        }

    }
}
