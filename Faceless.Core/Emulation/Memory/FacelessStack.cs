using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Memory {
    class FacelessStack : Stack<StackFrame> {

        public StackFrame CurrentFrame { get; private set; }



        public void NewFrame() {
            if(CurrentFrame != null) {
                this.Push(CurrentFrame);
            }
            CurrentFrame = new StackFrame();
        }

        public void NewFrameTransferItems(int ammount) {
            var newFrame = new StackFrame();
            foreach(object o in CurrentFrame.Pop(ammount)) {
                newFrame.Push(ammount);
            }
            this.Push(CurrentFrame);
            CurrentFrame = newFrame;
        }

        public void PreviousFrame() {
            if(this.Count > 0) {
                CurrentFrame = this.Pop();
            } else {
                CurrentFrame = new StackFrame();
            }
        }

    }
}
