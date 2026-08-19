using DVLD.User_Control;

namespace DVLD
{
    partial class FilterPersonInformation
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
            this.Gendor = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AddPerson = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cartPersonInformation1 = new DVLD.User_Control.CartPersonInformation();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gendor
            // 
            this.Gendor.AutoSize = true;
            this.Gendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gendor.Location = new System.Drawing.Point(15, 42);
            this.Gendor.Name = "Gendor";
            this.Gendor.Size = new System.Drawing.Size(13, 18);
            this.Gendor.TabIndex = 25;
            this.Gendor.Text = " ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Person ID",
            "National NO"});
            this.comboBox1.Location = new System.Drawing.Point(95, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 24);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(332, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 22);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddPerson
            // 
            this.AddPerson.Location = new System.Drawing.Point(677, 42);
            this.AddPerson.Name = "AddPerson";
            this.AddPerson.Size = new System.Drawing.Size(75, 23);
            this.AddPerson.TabIndex = 29;
            this.AddPerson.Text = "Add";
            this.AddPerson.UseVisualStyleBackColor = true;
            this.AddPerson.Click += new System.EventHandler(this.AddPerson_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.AddPerson);
            this.groupBox1.Controls.Add(this.Gendor);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 87);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cartPersonInformation1
            // 
            this.cartPersonInformation1.BackColor = System.Drawing.SystemColors.Desktop;
            this.cartPersonInformation1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cartPersonInformation1.Location = new System.Drawing.Point(3, 91);
            this.cartPersonInformation1.Name = "cartPersonInformation1";
            this.cartPersonInformation1.Size = new System.Drawing.Size(837, 272);
            this.cartPersonInformation1.TabIndex = 0;
            this.cartPersonInformation1.Load += new System.EventHandler(this.cartPersonInformation1_Load);
            // 
            // FilterPersonInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cartPersonInformation1);
            this.Name = "FilterPersonInformation";
            this.Size = new System.Drawing.Size(843, 366);
            this.Load += new System.EventHandler(this.FilterPersonInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CartPersonInformation cartPersonInformation1;
        private System.Windows.Forms.Label Gendor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddPerson;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
