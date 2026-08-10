namespace DVLD.People
{
    partial class AddUpdatePerson
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
            this.informationPerson1 = new DVLD.User_Control.InformationPerson();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // informationPerson1
            // 
            this.informationPerson1.Location = new System.Drawing.Point(12, 86);
            this.informationPerson1.Name = "informationPerson1";
            this.informationPerson1.Size = new System.Drawing.Size(854, 336);
            this.informationPerson1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add New Person";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.informationPerson1);
            this.Name = "AddUpdatePerson";
            this.Text = "AddUpdatePerson";
            this.Load += new System.EventHandler(this.AddUpdatePerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Control.InformationPerson informationPerson1;
        private System.Windows.Forms.Label label1;
    }
}