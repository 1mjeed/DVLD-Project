namespace DVLD.User
{
    partial class UserInformation
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
            this.userCartControl1 = new DVLD.User.UserCartControl();
            this.Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userCartControl1
            // 
            this.userCartControl1.Location = new System.Drawing.Point(3, 1);
            this.userCartControl1.Name = "userCartControl1";
            this.userCartControl1.Size = new System.Drawing.Size(910, 426);
            this.userCartControl1.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(3, 418);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(107, 38);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // UserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 460);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.userCartControl1);
            this.Name = "UserInformation";
            this.Text = "UserInformation";
            this.Load += new System.EventHandler(this.UserInformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserCartControl userCartControl1;
        private System.Windows.Forms.Button Close;
    }
}