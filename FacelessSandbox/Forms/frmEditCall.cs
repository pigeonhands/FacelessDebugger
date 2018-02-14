using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacelessSandbox.Forms {
    public partial class frmEditCall : Form {

        class CallingArgs {
            public object[] Args { get; set; }
            public CallingArgs(object[] _a) {
                Args = _a;
            }
        }

        public object[] Args {get; set;}// dataGridView1.Rows;
        public frmEditCall(string mName, object[] args) {
            Args = args;
            InitializeComponent();
            tbMethod.Text = mName;
            foreach(var o in args) {
                dataGridView1.Rows.Add(o);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var lo = new List<object>();
            foreach(var row in dataGridView1.Rows) {
                lo.Add(((DataGridViewRow)row).Cells[0].Value);
            }
            Args = lo.ToArray();
            DialogResult = DialogResult.OK;
        }
    }
}
