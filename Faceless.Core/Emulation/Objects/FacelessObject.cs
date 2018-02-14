using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Core.Emulation.Objects {
    public class FacelessObject {

        public TypeDef TargetType { get; }
        public string Name { get; }

        private FacelessValue[] Fields;
        public FacelessObject(TypeDef _type) {
            TargetType = _type;
            Fields = new FacelessValue[TargetType?.Fields.Count ?? 0];
        }



    }
}
