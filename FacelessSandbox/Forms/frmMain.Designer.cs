namespace FacelessSandbox.Forms {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSelect = new System.Windows.Forms.Button();
            this.tvCallStack = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExternalCallBreakpoint = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnBreakOnRet = new System.Windows.Forms.Button();
            this.cbPrintInstructions = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLoadedAssemblies = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(12, 484);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Run";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tvCallStack
            // 
            this.tvCallStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCallStack.Location = new System.Drawing.Point(3, 16);
            this.tvCallStack.Name = "tvCallStack";
            this.tvCallStack.Size = new System.Drawing.Size(411, 342);
            this.tvCallStack.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tvCallStack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 361);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Call stack";
            // 
            // cbExternalCallBreakpoint
            // 
            this.cbExternalCallBreakpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbExternalCallBreakpoint.AutoSize = true;
            this.cbExternalCallBreakpoint.Location = new System.Drawing.Point(169, 490);
            this.cbExternalCallBreakpoint.Name = "cbExternalCallBreakpoint";
            this.cbExternalCallBreakpoint.Size = new System.Drawing.Size(153, 17);
            this.cbExternalCallBreakpoint.TabIndex = 3;
            this.cbExternalCallBreakpoint.Text = "Break for edit external calls";
            this.cbExternalCallBreakpoint.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(88, 484);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnBreakOnRet
            // 
            this.btnBreakOnRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBreakOnRet.Location = new System.Drawing.Point(337, 484);
            this.btnBreakOnRet.Name = "btnBreakOnRet";
            this.btnBreakOnRet.Size = new System.Drawing.Size(75, 23);
            this.btnBreakOnRet.TabIndex = 5;
            this.btnBreakOnRet.Text = "Break on ret";
            this.btnBreakOnRet.UseVisualStyleBackColor = true;
            this.btnBreakOnRet.Click += new System.EventHandler(this.btnBreakOnRet_Click);
            // 
            // cbPrintInstructions
            // 
            this.cbPrintInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPrintInstructions.AutoSize = true;
            this.cbPrintInstructions.Location = new System.Drawing.Point(15, 457);
            this.cbPrintInstructions.Name = "cbPrintInstructions";
            this.cbPrintInstructions.Size = new System.Drawing.Size(104, 17);
            this.cbPrintInstructions.TabIndex = 6;
            this.cbPrintInstructions.Text = "Print Instructions";
            this.cbPrintInstructions.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lbLoadedAssemblies);
            this.groupBox2.Location = new System.Drawing.Point(15, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loaded Assemblies";
            // 
            // lbLoadedAssemblies
            // 
            this.lbLoadedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoadedAssemblies.FormattingEnabled = true;
            this.lbLoadedAssemblies.Location = new System.Drawing.Point(3, 16);
            this.lbLoadedAssemblies.Name = "lbLoadedAssemblies";
            this.lbLoadedAssemblies.Size = new System.Drawing.Size(408, 48);
            this.lbLoadedAssemblies.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbPrintInstructions);
            this.Controls.Add(this.btnBreakOnRet);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbExternalCallBreakpoint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelect);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TreeView tvCallStack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbExternalCallBreakpoint;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnBreakOnRet;
        private System.Windows.Forms.CheckBox cbPrintInstructions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbLoadedAssemblies;
    }
}