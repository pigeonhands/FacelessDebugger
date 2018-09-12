using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_stfld : FacelessInstruction {

        public Instruction_stfld() : base(Code.Stfld) { }

        public override void Execute(Instruction i, Emulator emulator) {

            if (!(i.Operand is FieldDef)) {
                throw new NotImplementedException("Internal types only currently.");
            }

            var field = (FieldDef)i.Operand;

            var val = emulator.MemoryStack.CurrentFrame.Pop();
            var obj = (FacelessValue)emulator.MemoryStack.CurrentFrame.Pop();
            
            if(obj.Value is FacelessObject) {
                ((FacelessObject)obj.Value).SetField(field.Rid, new FacelessValue(val, null));
            } else {
                FieldInfo reflectedField = obj.GetType().GetField(field.Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
                reflectedField.SetValue(obj, val);
            }
        }
    }
}
