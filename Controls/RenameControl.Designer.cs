namespace SQlite.WF.Controls
{
    partial class RenameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChangeText = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblChangeText
            // 
            this.lblChangeText.AutoSize = true;
            this.lblChangeText.Location = new System.Drawing.Point(16, 68);
            this.lblChangeText.Name = "lblChangeText";
            this.lblChangeText.Size = new System.Drawing.Size(131, 17);
            this.lblChangeText.TabIndex = 0;
            this.lblChangeText.Text = "Change table name";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(19, 109);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(225, 22);
            this.tbTableName.TabIndex = 1;
            this.tbTableName.Text = "s";
            // 
            // RenameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.lblChangeText);
            this.Name = "RenameControl";
            this.Size = new System.Drawing.Size(309, 211);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChangeText;
        private System.Windows.Forms.TextBox tbTableName;
    }
}
