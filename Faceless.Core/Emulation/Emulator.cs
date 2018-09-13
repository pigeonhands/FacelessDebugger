using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation.Memory;
using dnlib.DotNet;
using Faceless.Core.Emulation.Instructions;
using Faceless.Core.Exceptions;
using Faceless.Core.Emulation.Objects;

namespace Faceless.Core.Emulation {
    internal class Emulator {

        public bool CanEmulate => CurrentCall != null && !CurrentCall.EndOfMethod;

        public event OnInternalCallDelegate OnInternalCall;
        public event OnExternalCallDelegate OnExternalCall;
        public event OnLoadExternalAssemblyDelegate OnExternalAssemblyLoad;

        internal EmulatedCall CurrentCall { get; set; }
        internal FacelessStack MemoryStack { get; } = new FacelessStack();

        private Dictionary<Code, FacelessInstruction> InstructionSet = new Dictionary<Code, FacelessInstruction>();

        private AppDomain sandboxDomain;

        public Emulator(MethodDef method) {
            CurrentCall = new EmulatedCall(null, method);
            MemoryStack.NewFrame();

            sandboxDomain = AppDomain.CreateDomain("sandboxDomain");


            #region Instructions #

            AddInstructions(new FacelessInstruction[] {
                new Instruction_ldnull(),
                new Instruction_nop(),
                new Instruction_ld(Code.Ldc_I4),
                new Instruction_ld(Code.Ldc_I8),
                new Instruction_ld(Code.Ldc_R4),
                new Instruction_ld(Code.Ldc_R8),
                new Instruction_ld(Code.Ldstr),
                new Instruction_dup(),
                new Instruction_pop(),
                new Instruction_call(Code.Call),
                new Instruction_call(Code.Callvirt),
                new Instruction_ret(),
                new Instruction_stloc(),
                new Instruction_ldloc(),
                new Instruction_newobj(),
                new Instruction_br(),
                new Instruction_ldarg(),
                new Instruction_clt(),
                new Instruction_brtrue(),
                new Instruction_add(),
                new Instruction_sub(),
                new Instruction_xor(),
                new Instruction_mul(),
                new Instruction_starg(),
                new Instruction_ceq(),
                new Instruction_brfalse(),
                new Instruction_stfld(),
                new Instruction_ldfld(),

            });

            #endregion
        }

        private void AddInstructions(FacelessInstruction[] instructions) {
            foreach(FacelessInstruction i in instructions) {
                InstructionSet.Add(i.InstructionCode, i);
            }
        }

        public bool ShouldCallExternal(IMethodDefOrRef method, object[] args) {
            return OnExternalCall?.Invoke(null, method, args) ?? true;
        }

        public bool ShouldCallInternal (IMethodDefOrRef method, FacelessValue[] args) {
            return OnInternalCall?.Invoke(null, method, args) ?? true;
        }

        public Instruction NextInstruction() => CurrentCall.NextInstruction();

        public void RunInstruction(Instruction ins) {

            if(ins.OpCode.OpCodeType == OpCodeType.Macro) {
                throw new CantHandleInstructionException($"{ins.OpCode.Name} is macro. Simplify macro failed for method {CurrentCall.MethodDefinition.Name}");
            }
            if(!InstructionSet.TryGetValue(ins.OpCode.Code, out FacelessInstruction fi)) {
                throw new CantHandleInstructionException($"No handler found for OpCode {ins.OpCode.Name}");
            }

            fi.Execute(ins, this);

        }

        public Type ResolveReflectiveType(ITypeDefOrRef type) {
            var loadedAssemblies = sandboxDomain
                   .GetAssemblies();
            var asm = loadedAssemblies
                .FirstOrDefault(x => x.FullName == type.DefinitionAssembly.FullName);

            if(asm == null) {
                /* Load assembly */
                if(!OnExternalAssemblyLoad?.Invoke(null, type.DefinitionAssembly) ?? true) {
                    return null;
                }
                asm = sandboxDomain.Load(type.DefinitionAssembly.FullName);
            }

            return asm.GetType(type.ReflectionFullName); ;
        }

    }
}
