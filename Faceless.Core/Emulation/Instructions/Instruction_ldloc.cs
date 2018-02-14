using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ldloc : FacelessInstruction {
        public Instruction_ldloc() : base(Code.Ldloc) {
        }
        public override void Execute(Instruction i, Emulator emulator) {
            Local l = (Local)i.Operand;
            emulator.MemoryStack.CurrentFrame.Push(emulator.CurrentCall.Locals[l.Index]);
        }
    }
}
