using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Objects {
    public class FacelessValue {

        public object Value { get; set; }
        public TypeSig CilType { get; }

        public FacelessValue(object _value, TypeSig _t) {
            Value = _value;
            CilType = _t;

        }

        public override string ToString() {
            return $"FacelessValue[{CilType}] ({Value})";
        }

    }
}
