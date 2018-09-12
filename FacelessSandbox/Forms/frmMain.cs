using dnlib.DotNet;
using Faceless.Core;
using Faceless.Core.Emulation.Objects;
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
    public partial class frmMain : Form {

        FacelessAssembly fasm;
        bool running = true;
        TreeNode currentNode;
        public frmMain() {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            using(OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Application|*.exe";
                if(ofd.ShowDialog() == DialogResult.OK) {
                    fasm = FacelessAssembly.Create(ofd.FileName);
                    tvCallStack.Nodes.Clear();
                    currentNode = new TreeNode(fasm.CurrentMethodName) {
                        ForeColor = Color.DarkMagenta
                    };
                    tvCallStack.Nodes.Add(currentNode);

                    fasm.OnInstruction += Fasm_OnInstruction;
                    fasm.OnException += Fasm_OnException;
                    fasm.OnExternalCall += Fasm_OnExternalCall;
                    fasm.OnInternalCall += Fasm_OnInternalCall;

                    Run();
                }
            }
        }

        private void Run() {
            btnContinue.Enabled = false;
            while (fasm.CanEmulate && running) {
                fasm.RunNextInstruction();
            }
        }
        private void btnContinue_Click(object sender, EventArgs e) {
            running = true;
            Run();
        }

        private void btnBreakOnRet_Click(object sender, EventArgs e) {
            var node = tvCallStack.SelectedNode;
            if (node != null) {
                node.Tag = true;
                node.ForeColor = Color.Red;
            }
        }

        private bool Fasm_OnInternalCall(FacelessAssembly sender, IMethodDefOrRef method, FacelessValue[] args) {
            var newNode = new TreeNode(method.FullName);
            
            var argsNode = new TreeNode("args");
            foreach (var a in args) {
                argsNode.Nodes.Add(a.ToString());
            }
            newNode.Nodes.Add(argsNode);
            
            currentNode.Nodes.Add(newNode);
            currentNode.ForeColor = Color.Black;

            currentNode = newNode;
            currentNode.ForeColor = Color.DarkMagenta;
            return true;
        }

        private bool Fasm_OnExternalCall(FacelessAssembly sender, IMethodDefOrRef method, object[] args) {

            var node = new TreeNode(method.FullName);
            node.ForeColor = Color.DarkMagenta;
            currentNode.Nodes.Add(node);

            if (cbExternalCallBreakpoint.Checked && args.Length > 0) {
                using (var frm = new frmEditCall(method.FullName, args)) {
                    if (frm.ShowDialog() == DialogResult.OK) {
                        for (int i = 0; i < args.Length; i++) {
                            args[i] = frm.Args[i];
                        }
                    }
                }
                running = false;
                btnContinue.Enabled = true;
            }

            var argsNode = new TreeNode("args");
            foreach(var a in args) {
                argsNode.Nodes.Add(a.ToString());
            }
            node.Nodes.Add(argsNode);
            node.ForeColor = Color.Black;


            return true;
        }

       

        private void Fasm_OnException(FacelessAssembly sender, Exception ex) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[{0}]: {1}", ex.GetType().Name, ex.Message);
            Console.WriteLine(ex.ToString());
            Console.ResetColor();
        }

        private bool Fasm_OnInstruction(FacelessAssembly sender, dnlib.DotNet.Emit.Instruction instruction) {
            if (cbPrintInstructions.Checked) {
                Console.WriteLine(">\t{0}\t({1}) {2}", instruction.OpCode, instruction.Operand?.GetType().Name ?? "null", instruction.Operand);
            }
            

            if (instruction.OpCode.Code == dnlib.DotNet.Emit.Code.Ret) {
                if(currentNode?.Tag is bool) {
                    currentNode.ForeColor = Color.Green;
                    cbExternalCallBreakpoint.Checked = (bool)currentNode.Tag;
                } else {
                    currentNode.ForeColor = Color.Black;
                }
                currentNode = currentNode.Parent;
            }

            return true;
        }

        
    }
}
