using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using dnlib.DotNet;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ldarg : FacelessInstruction {
        public Instruction_ldarg() : base(Code.Ldarg) {
        }
        protected override void Handle(Instruction i, Emulator emulator) {
            Parameter p = (Parameter)i.Operand;
            emulator.MemoryStack.CurrentFrame.Push(emulator.CurrentCall.Parameters[p.Index]);
        }
    }
}
