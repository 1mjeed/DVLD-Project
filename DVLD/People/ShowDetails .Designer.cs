namespace DVLD.People
{
    partial class ShowDetails
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
            this.cartPersonInformation1 = new DVLD.User_Control.CartPersonInformation();
            this.SuspendLayout();
            // 
            // cartPersonInformation1
            // 
            this.cartPersonInformation1.BackColor = System.Drawing.SystemColors.Desktop;
            this.cartPersonInformation1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cartPersonInformation1.Location = new System.Drawing.Point(-2, 0);
            this.cartPersonInformation1.Name = "cartPersonInformation1";
            this.cartPersonInformation1.Size = new System.Drawing.Size(826, 243);
            this.cartPersonInformation1.TabIndex = 0;
            // 
            // ShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 241);
            this.Controls.Add(this.cartPersonInformation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ShowDetails";
            this.Text = "ShowDetails";
            this.Load += new System.EventHandler(this.ShowDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Control.CartPersonInformation cartPersonInformation1;
    }
}