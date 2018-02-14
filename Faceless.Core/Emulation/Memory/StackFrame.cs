using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Memory {
    internal class StackFrame {

        private Stack<object> items = new Stack<object>();

        public void Push(object o) {
            items.Push(o);
        }

        public object Pop() {
            return items.Pop();
        }

        public IEnumerable<object> Pop(int ammout) {
            for(int i = 0; i < ammout; i++) {
                yield return items.Pop();
            }
        }

    }
}
