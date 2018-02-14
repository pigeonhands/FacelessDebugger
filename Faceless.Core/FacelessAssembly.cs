using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib;
using dnlib.DotNet;
using System.IO;
using dnlib.DotNet.Emit;
using Faceless.Core.Emulation;

namespace Faceless.Core {
    public delegate bool OnInstructionDelegate(FacelessAssembly sender, Instruction instruction);
    public delegate void OnExceptionDelegate(FacelessAssembly sender, Exception ex);
    public delegate bool OnCallDelegate(FacelessAssembly sender, IMethodDefOrRef method, object[] args);
    public class FacelessAssembly {

        #region " Static creators "

        public static FacelessAssembly Create(MethodDef targetMethod) => new FacelessAssembly(targetMethod);
        public static FacelessAssembly Create(string path) => Create(ModuleDefMD.Load(path).EntryPoint);
        public static FacelessAssembly Create(byte[] assemblybytes) => Create(ModuleDefMD.Load(assemblybytes).EntryPoint);
        public static FacelessAssembly Create(Stream assemblyStream) => Create(ModuleDefMD.Load(assemblyStream).EntryPoint);
        public static FacelessAssembly Create(System.Reflection.Module modTarget) => Create(ModuleDefMD.Load(modTarget).EntryPoint);

        #endregion

        #region " Events "

        public event OnInstructionDelegate OnInstruction;
        public event OnExceptionDelegate OnException;


        public event OnCallDelegate OnInternalCall;

        public event OnCallDelegate OnExternalCall;

        #endregion


        private Emulator Emulator;
        public bool CanEmulate => Emulator.CanEmulate;
        public string CurrentMethodName => Emulator.CurrentCall.MethodDefinition.FullName;

        private FacelessAssembly(MethodDef _startingMethodBody) {
            Emulator = new Emulator(_startingMethodBody);
            Emulator.OnExternalCall += Emulator_OnExternalCall;
            Emulator.OnInternalCall += Emulator_OnInternalCall;
        }

        private bool Emulator_OnInternalCall(FacelessAssembly sender, IMethodDefOrRef method, object[] args) {
            return OnInternalCall?.Invoke(this, method, args) ?? true;
        }

        private bool Emulator_OnExternalCall(FacelessAssembly sender, IMethodDefOrRef method, object[] args) {
            return OnExternalCall?.Invoke(this, method, args) ?? true;
        }

        public void RunNextInstruction() {
            if (!CanEmulate) {
                throw new Exception("Cannot emulate any more.");
            }
            var nextInstruction = Emulator.NextInstruction();
            if(OnInstruction?.Invoke(this, nextInstruction) ?? true) {
                try {
                    Emulator.RunInstruction(nextInstruction);
                }catch(Exception ex) {
                    OnException?.Invoke(this, ex);
                }
            }
        }



    }
}
