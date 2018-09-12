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
            Name = TargetType.Name;
            Fields = new FacelessValue[TargetType?.Fields.Count ?? 0];
        }

        public void SetField(uint id, FacelessValue fv) {
            Fields[id - 1] = fv;
        }

        public FacelessValue GetField(uint id) => Fields[id - 1];

    }
}
