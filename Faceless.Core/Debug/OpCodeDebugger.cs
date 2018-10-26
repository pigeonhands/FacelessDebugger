using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Debug {
    internal class OpCodeDebugger {

        public static OpCodeDebugger Instance { get; } = new OpCodeDebugger();

        private readonly HashSet<Code> breakpointOpcodes = new HashSet<Code>();

        private OpCodeDebugger() {
        }

        public void AddBrakpoint(Code c) =>
            breakpointOpcodes.Add(c);

        public void RemoveBreakpoint(Code c) =>
            breakpointOpcodes.Add(c);

        public bool ShouldBreakpoint(Code c) => breakpointOpcodes.Contains(c);
    }
}
