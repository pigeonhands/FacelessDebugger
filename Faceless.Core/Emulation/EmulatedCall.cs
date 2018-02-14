using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation {
    internal class EmulatedCall {

        public EmulatedCall ParentCall { get; private set; }
        public int BodyIndex { get; internal set; }
        public bool EndOfMethod => !(BodyIndex < Body.Instructions.Count);

        public MethodDef MethodDefinition { get; private set; }
        public CilBody Body => MethodDefinition.Body;

        public FacelessValue[] Parameters { get; }
        public object[] Locals { get; }


        public EmulatedCall(EmulatedCall _parent, MethodDef __method, FacelessValue[] args) {
            ParentCall = _parent;
            MethodDefinition = __method;
            Parameters = args;

            if (__method.HasBody) {
                Locals = new object[Body.Variables.Count];

                Body.SimplifyMacros(MethodDefinition.Parameters);
                Body.SimplifyBranches();
            } else {
                Locals = new object[0];
            }
            
        }
        public EmulatedCall(EmulatedCall _parent, MethodDef __method) : this(_parent, __method, new FacelessValue[0]) {
        }

        public void GotoInstruction(Instruction i) {
            BodyIndex = Body.Instructions.IndexOf(i);
        }

        public Instruction NextInstruction() {
            return Body.Instructions[BodyIndex++];
        }
    }
}
