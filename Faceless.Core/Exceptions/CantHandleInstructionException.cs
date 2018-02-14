using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Exceptions {
    public class CantHandleInstructionException : Exception {
        public CantHandleInstructionException(string reason) : base(reason) {

        }
    }
}
