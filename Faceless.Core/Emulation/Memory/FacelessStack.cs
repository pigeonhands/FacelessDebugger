using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Memory {
    class FacelessStack {

        public StackFrame CurrentFrame { get; private set; }

        private Stack<StackFrame> frames = new Stack<StackFrame>();
        

        public void NewFrame() {
            if(CurrentFrame != null) {
                frames.Push(CurrentFrame);
            }
            CurrentFrame = new StackFrame();
        }

        public void NewFrameTransferItems(int ammount) {
            var newFrame = new StackFrame();
            foreach(object o in CurrentFrame.Pop(ammount)) {
                newFrame.Push(ammount);
            }
            frames.Push(CurrentFrame);
            CurrentFrame = newFrame;
        }

        public void PreviousFrame() {
            if(frames.Count > 0) {
                CurrentFrame = frames.Pop();
            } else {
                CurrentFrame = new StackFrame();
            }
        }

    }
}
