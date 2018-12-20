namespace EmailApp
{
    partial class Configure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBCCClear = new System.Windows.Forms.Button();
            this.btnCCClear = new System.Windows.Forms.Button();
            this.btnToClear = new System.Windows.Forms.Button();
            this.btnBCCAdd = new System.Windows.Forms.Button();
            this.txtBCC = new System.Windows.Forms.TextBox();
            this.lblBCC = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGoogleSheetURL = new System.Windows.Forms.TextBox();
            this.lblGoogleSheetURL = new System.Windows.Forms.Label();
            this.rdoReadFromGoogleSheetNo = new System.Windows.Forms.RadioButton();
            this.lblReadFromGoogleSheet = new System.Windows.Forms.Label();
            this.rdoReadFromGoogleSheetYes = new System.Windows.Forms.RadioButton();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnCCAdd = new System.Windows.Forms.Button();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.lblCC = new System.Windows.Forms.Label();
            this.btbToAdd = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBCCClear
            // 
            this.btnBCCClear.Location = new System.Drawing.Point(749, 185);
            this.btnBCCClear.Name = "btnBCCClear";
            this.btnBCCClear.Size = new System.Drawing.Size(75, 23);
            this.btnBCCClear.TabIndex = 53;
            this.btnBCCClear.Text = "Clear";
            this.btnBCCClear.UseVisualStyleBackColor = true;
            this.btnBCCClear.Click += new System.EventHandler(this.btnBCCClear_Click);
            // 
            // btnCCClear
            // 
            this.btnCCClear.Location = new System.Drawing.Point(749, 143);
            this.btnCCClear.Name = "btnCCClear";
            this.btnCCClear.Size = new System.Drawing.Size(75, 23);
            this.btnCCClear.TabIndex = 52;
            this.btnCCClear.Text = "Clear";
            this.btnCCClear.UseVisualStyleBackColor = true;
            this.btnCCClear.Click += new System.EventHandler(this.btnCCClear_Click);
            // 
            // btnToClear
            // 
            this.btnToClear.Location = new System.Drawing.Point(749, 104);
            this.btnToClear.Name = "btnToClear";
            this.btnToClear.Size = new System.Drawing.Size(75, 23);
            this.btnToClear.TabIndex = 51;
            this.btnToClear.Text = "Clear";
            this.btnToClear.UseVisualStyleBackColor = true;
            this.btnToClear.Click += new System.EventHandler(this.btnToClear_Click);
            // 
            // btnBCCAdd
            // 
            this.btnBCCAdd.Location = new System.Drawing.Point(651, 185);
            this.btnBCCAdd.Name = "btnBCCAdd";
            this.btnBCCAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBCCAdd.TabIndex = 50;
            this.btnBCCAdd.Text = "Add";
            this.btnBCCAdd.UseVisualStyleBackColor = true;
            this.btnBCCAdd.Click += new System.EventHandler(this.btnBCCAdd_Click);
            // 
            // txtBCC
            // 
            this.txtBCC.Location = new System.Drawing.Point(228, 185);
            this.txtBCC.Name = "txtBCC";
            this.txtBCC.ReadOnly = true;
            this.txtBCC.Size = new System.Drawing.Size(393, 20);
            this.txtBCC.TabIndex = 49;
            // 
            // lblBCC
            // 
            this.lblBCC.AutoSize = true;
            this.lblBCC.Location = new System.Drawing.Point(73, 188);
            this.lblBCC.Name = "lblBCC";
            this.lblBCC.Size = new System.Drawing.Size(28, 13);
            this.lblBCC.TabIndex = 48;
            this.lblBCC.Text = "BCC";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(76, 439);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 46;
            this.lblPassword.Text = "Password";
            this.lblPassword.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(228, 439);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(393, 20);
            this.txtPassword.TabIndex = 45;
            this.txtPassword.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGoogleSheetURL
            // 
            this.txtGoogleSheetURL.Location = new System.Drawing.Point(228, 476);
            this.txtGoogleSheetURL.Name = "txtGoogleSheetURL";
            this.txtGoogleSheetURL.Size = new System.Drawing.Size(393, 20);
            this.txtGoogleSheetURL.TabIndex = 43;
            this.txtGoogleSheetURL.Visible = false;
            // 
            // lblGoogleSheetURL
            // 
            this.lblGoogleSheetURL.AutoSize = true;
            this.lblGoogleSheetURL.Location = new System.Drawing.Point(76, 476);
            this.lblGoogleSheetURL.Name = "lblGoogleSheetURL";
            this.lblGoogleSheetURL.Size = new System.Drawing.Size(94, 13);
            this.lblGoogleSheetURL.TabIndex = 42;
            this.lblGoogleSheetURL.Text = "GoogleSheet URL";
            this.lblGoogleSheetURL.Visible = false;
            // 
            // rdoReadFromGoogleSheetNo
            // 
            this.rdoReadFromGoogleSheetNo.AutoSize = true;
            this.rdoReadFromGoogleSheetNo.Location = new System.Drawing.Point(287, 396);
            this.rdoReadFromGoogleSheetNo.Name = "rdoReadFromGoogleSheetNo";
            this.rdoReadFromGoogleSheetNo.Size = new System.Drawing.Size(39, 17);
            this.rdoReadFromGoogleSheetNo.TabIndex = 41;
            this.rdoReadFromGoogleSheetNo.TabStop = true;
            this.rdoReadFromGoogleSheetNo.Text = "No";
            this.rdoReadFromGoogleSheetNo.UseVisualStyleBackColor = true;
            this.rdoReadFromGoogleSheetNo.CheckedChanged += new System.EventHandler(this.rdoReadFromGoogleSheetNo_CheckedChanged);
            // 
            // lblReadFromGoogleSheet
            // 
            this.lblReadFromGoogleSheet.AutoSize = true;
            this.lblReadFromGoogleSheet.Location = new System.Drawing.Point(76, 396);
            this.lblReadFromGoogleSheet.Name = "lblReadFromGoogleSheet";
            this.lblReadFromGoogleSheet.Size = new System.Drawing.Size(124, 13);
            this.lblReadFromGoogleSheet.TabIndex = 40;
            this.lblReadFromGoogleSheet.Text = "Read From GoogleSheet";
            // 
            // rdoReadFromGoogleSheetYes
            // 
            this.rdoReadFromGoogleSheetYes.AutoSize = true;
            this.rdoReadFromGoogleSheetYes.Location = new System.Drawing.Point(228, 396);
            this.rdoReadFromGoogleSheetYes.Name = "rdoReadFromGoogleSheetYes";
            this.rdoReadFromGoogleSheetYes.Size = new System.Drawing.Size(43, 17);
            this.rdoReadFromGoogleSheetYes.TabIndex = 39;
            this.rdoReadFromGoogleSheetYes.TabStop = true;
            this.rdoReadFromGoogleSheetYes.Text = "Yes";
            this.rdoReadFromGoogleSheetYes.UseVisualStyleBackColor = true;
            this.rdoReadFromGoogleSheetYes.CheckedChanged += new System.EventHandler(this.rdoReadFromGoogleSheetYes_CheckedChanged);
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(228, 268);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(393, 111);
            this.txtBody.TabIndex = 38;
            this.txtBody.Text = "";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(73, 268);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(31, 13);
            this.lblBody.TabIndex = 37;
            this.lblBody.Text = "Body";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(228, 231);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(393, 20);
            this.txtSubject.TabIndex = 36;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(73, 231);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 35;
            this.lblSubject.Text = "Subject";
            // 
            // btnCCAdd
            // 
            this.btnCCAdd.Location = new System.Drawing.Point(651, 143);
            this.btnCCAdd.Name = "btnCCAdd";
            this.btnCCAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCCAdd.TabIndex = 34;
            this.btnCCAdd.Text = "Add";
            this.btnCCAdd.UseVisualStyleBackColor = true;
            this.btnCCAdd.Click += new System.EventHandler(this.btnCCAdd_Click);
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(228, 143);
            this.txtCC.Name = "txtCC";
            this.txtCC.ReadOnly = true;
            this.txtCC.Size = new System.Drawing.Size(393, 20);
            this.txtCC.TabIndex = 33;
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(73, 143);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(21, 13);
            this.lblCC.TabIndex = 32;
            this.lblCC.Text = "CC";
            // 
            // btbToAdd
            // 
            this.btbToAdd.Location = new System.Drawing.Point(651, 104);
            this.btbToAdd.Name = "btbToAdd";
            this.btbToAdd.Size = new System.Drawing.Size(75, 23);
            this.btbToAdd.TabIndex = 31;
            this.btbToAdd.Text = "Add";
            this.btbToAdd.UseVisualStyleBackColor = true;
            this.btbToAdd.Click += new System.EventHandler(this.btbToAdd_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(228, 104);
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(393, 20);
            this.txtTo.TabIndex = 30;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(73, 107);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 29;
            this.lblTo.Text = "To";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(228, 66);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(393, 20);
            this.txtFrom.TabIndex = 28;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(73, 66);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 27;
            this.lblFrom.Text = "From";
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 548);
            this.Controls.Add(this.btnBCCClear);
            this.Controls.Add(this.btnCCClear);
            this.Controls.Add(this.btnToClear);
            this.Controls.Add(this.btnBCCAdd);
            this.Controls.Add(this.txtBCC);
            this.Controls.Add(this.lblBCC);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGoogleSheetURL);
            this.Controls.Add(this.lblGoogleSheetURL);
            this.Controls.Add(this.rdoReadFromGoogleSheetNo);
            this.Controls.Add(this.lblReadFromGoogleSheet);
            this.Controls.Add(this.rdoReadFromGoogleSheetYes);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnCCAdd);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.btbToAdd);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblFrom);
            this.Name = "Configure";
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBCCClear;
        private System.Windows.Forms.Button btnCCClear;
        private System.Windows.Forms.Button btnToClear;
        private System.Windows.Forms.Button btnBCCAdd;
        private System.Windows.Forms.TextBox txtBCC;
        private System.Windows.Forms.Label lblBCC;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGoogleSheetURL;
        private System.Windows.Forms.Label lblGoogleSheetURL;
        private System.Windows.Forms.RadioButton rdoReadFromGoogleSheetNo;
        private System.Windows.Forms.Label lblReadFromGoogleSheet;
        private System.Windows.Forms.RadioButton rdoReadFromGoogleSheetYes;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnCCAdd;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.Button btbToAdd;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
    }
}