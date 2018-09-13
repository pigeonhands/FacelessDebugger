using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Faceless.Core.Emulation.Instructions {
    internal class Instruction_ldftn : FacelessInstruction {

        public Instruction_ldftn() : base(dnlib.DotNet.Emit.Code.Ldftn) {
        }

        public override void Execute(Instruction i, Emulator emulator) {
            throw new NotImplementedException("ldftn instruction currently does not work. Thinking for a way to emulate callbacks.");

            var m = (MethodDef)i.Operand;


            Type t = emulator.ResolveReflectiveType(m.DeclaringType);

            Type[] callParamTypes = m.MethodSig.Params.Select(x => emulator.ResolveReflectiveType(x.ToTypeDefOrRef())).ToArray();
            MethodInfo mi = t.GetMethod(m.Name, callParamTypes);

            emulator.MemoryStack.CurrentFrame.Push(mi.MethodHandle.Value.ToInt32());
        }
    }
}
