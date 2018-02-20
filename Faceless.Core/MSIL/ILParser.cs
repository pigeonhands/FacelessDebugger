using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.MSIL {
    public class ILParser : IDisposable {

        public bool EndOfMethod => !(bytecode.CanRead && bytecode.Position < bytecode.Length);

        private MemoryStream bytecode;

        #region " Static Opcode resources "

        private static OpCode[] singleByteOpCodes;
        private static OpCode[] multiByteOpCodes;
        
        static ILParser() {
            LoadOpCodes();
        }
        public static void LoadOpCodes() {
            singleByteOpCodes = new OpCode[0x100];
            multiByteOpCodes = new OpCode[0x100];

            IEnumerable<OpCode> opcodes =
                typeof(OpCodes).GetFields()
                .Where(f => f.FieldType == typeof(OpCode))
                .Select(x => (OpCode)x.GetValue(null));

            foreach (OpCode op in opcodes) {
                ushort bytecode = (ushort)op.Value;
                if (bytecode < 0x100) {
                    singleByteOpCodes[bytecode] = op;
                } else {
                    multiByteOpCodes[bytecode & 0x00ff] = op;
                }
            }
        }

        #endregion


        public ILParser(byte[] _src) {
            MethodInfo mi;
            bytecode = new MemoryStream(_src);
        }

        private OpCode ReadOpCode() {
            byte code = (byte)bytecode.ReadByte();
            if (code != 0xFE) {
                return singleByteOpCodes[code];
            } else {
                return multiByteOpCodes[(byte)bytecode.ReadByte()];
            }
        }

        private object ReadOperand(OpCode op) {
            switch (op.OperandType) {

            }
            throw new NotImplementedException();

        }

        public ILInstruction ReadOneInstruction() {
            if (EndOfMethod) {
                return null;
            }

            OpCode opcode = ReadOpCode();

            throw new NotImplementedException();
        }

        public void Dispose() {
            bytecode.Dispose();
        }
    }
}
