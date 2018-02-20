using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.MSIL {
    public class ILInstruction {

        public int Position { get; }
        public OpCode OpCode { get; }
        public object Operand { get; }

        internal ILInstruction(int _position, OpCode _opcode, object _operand) {
            Position = _position;
            OpCode = _opcode;
            Operand = _operand;
        }

    }
}
