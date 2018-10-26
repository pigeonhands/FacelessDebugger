using dnlib.DotNet.Emit;
using Faceless.Core.Debug;
using Faceless.Core.Emulation.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Instructions {
    internal abstract class FacelessInstruction {

        public Code InstructionCode { get; private set; }
        public FacelessInstruction(Code _code) {
            InstructionCode = _code;
        }

        public void Process(Instruction i, Emulator emulator) {
            if (OpCodeDebugger.Instance.ShouldBreakpoint(InstructionCode)) {
                Debugger.Break();
            }
            Handle(i, emulator);
        }
        protected abstract void Handle(Instruction i, Emulator emulator);

        protected dynamic[] GetStackValues(int i, Emulator emulator) {
            return emulator.MemoryStack
              .CurrentFrame.Pop(2)
              .Select(x => (x is FacelessValue) ? ((FacelessValue)x).Value : x)
              .ToArray();
        }

    }
}
