using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using dnlib.DotNet;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_starg : FacelessInstruction {
        public Instruction_starg() : base(Code.Starg) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            Parameter p = (Parameter)i.Operand;
            emulator.CurrentCall.Parameters[p.Index] = new FacelessValue(emulator.MemoryStack.CurrentFrame.Pop(), p.Type);
        }
    }
}
