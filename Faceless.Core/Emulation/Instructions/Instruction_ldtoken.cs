using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    class Instruction_ldtoken : FacelessInstruction {

        public Instruction_ldtoken() : base(Code.Ldtoken) { }
        protected override void Handle(Instruction i, Emulator emulator)  {
            Debugger.Break();
        }
    }
}
