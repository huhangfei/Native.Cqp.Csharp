namespace Native.Csharp.App.UI
{
    partial class Main
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
            this.sendRecordBtn = new System.Windows.Forms.Button();
            this.groupIdText = new System.Windows.Forms.TextBox();
            this.recordPathText = new System.Windows.Forms.TextBox();
            this.sendTxtBtn = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendRecordBtn
            // 
            this.sendRecordBtn.Location = new System.Drawing.Point(431, 24);
            this.sendRecordBtn.Name = "sendRecordBtn";
            this.sendRecordBtn.Size = new System.Drawing.Size(75, 23);
            this.sendRecordBtn.TabIndex = 0;
            this.sendRecordBtn.Text = "发送";
            this.sendRecordBtn.UseVisualStyleBackColor = true;
            this.sendRecordBtn.Click += new System.EventHandler(this.sendRecordBtn_Click);
            // 
            // groupIdText
            // 
            this.groupIdText.Location = new System.Drawing.Point(25, 26);
            this.groupIdText.Name = "groupIdText";
            this.groupIdText.Size = new System.Drawing.Size(100, 21);
            this.groupIdText.TabIndex = 1;
            this.groupIdText.Text = "852797927";
            // 
            // recordPathText
            // 
            this.recordPathText.Location = new System.Drawing.Point(165, 26);
            this.recordPathText.Name = "recordPathText";
            this.recordPathText.Size = new System.Drawing.Size(239, 21);
            this.recordPathText.TabIndex = 2;
            this.recordPathText.Text = "404.mp3";
            // 
            // sendTxtBtn
            // 
            this.sendTxtBtn.Location = new System.Drawing.Point(431, 127);
            this.sendTxtBtn.Name = "sendTxtBtn";
            this.sendTxtBtn.Size = new System.Drawing.Size(75, 23);
            this.sendTxtBtn.TabIndex = 3;
            this.sendTxtBtn.Text = "发送";
            this.sendTxtBtn.UseVisualStyleBackColor = true;
            this.sendTxtBtn.Click += new System.EventHandler(this.sendTxtBtn_Click);
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(165, 54);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(239, 96);
            this.messageText.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.sendTxtBtn);
            this.Controls.Add(this.recordPathText);
            this.Controls.Add(this.groupIdText);
            this.Controls.Add(this.sendRecordBtn);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendRecordBtn;
        private System.Windows.Forms.TextBox groupIdText;
        private System.Windows.Forms.TextBox recordPathText;
        private System.Windows.Forms.Button sendTxtBtn;
        private System.Windows.Forms.TextBox messageText;
    }
}