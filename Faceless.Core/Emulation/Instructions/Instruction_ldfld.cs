using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ldfld : FacelessInstruction {

        public Instruction_ldfld() : base(Code.Ldfld) {

        }

        public override void Execute(Instruction i, Emulator emulator) {

            if (!(i.Operand is FieldDef)) {
                throw new NotImplementedException("Internal types only currently.");
            }

            var field = (FieldDef)i.Operand; /* only internal types currently! */

            var obj = (FacelessValue)emulator.MemoryStack.CurrentFrame.Pop();

            object pushValue = null;

            if (obj.Value is FacelessObject) {
                pushValue = ((FacelessObject)obj.Value).GetField(field.Rid).Value;
            } else {
                 //TODO
            }

            emulator.MemoryStack.CurrentFrame.Push(pushValue);

        }
    }
}
