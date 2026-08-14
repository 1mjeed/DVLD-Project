namespace DVLD.Applications
{
    partial class NewLocalDrivingApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.filterPersonInformation1 = new DVLD.FilterPersonInformation();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.laFees = new System.Windows.Forms.Label();
            this.laCreatedBy = new System.Windows.Forms.Label();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.laDate = new System.Windows.Forms.Label();
            this.laid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Gendor = new System.Windows.Forms.Label();
            this.butNext = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(838, 390);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.filterPersonInformation1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(830, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // filterPersonInformation1
            // 
            this.filterPersonInformation1.BackColor = System.Drawing.SystemColors.Desktop;
            this.filterPersonInformation1.FilterEnabled = true;
            this.filterPersonInformation1.Location = new System.Drawing.Point(6, 6);
            this.filterPersonInformation1.Name = "filterPersonInformation1";
            this.filterPersonInformation1.ShowAddPerson = true;
            this.filterPersonInformation1.Size = new System.Drawing.Size(821, 359);
            this.filterPersonInformation1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.RosyBrown;
            this.tabPage2.Controls.Add(this.lblTitle);
            this.tabPage2.Controls.Add(this.cbLicenseClass);
            this.tabPage2.Controls.Add(this.laFees);
            this.tabPage2.Controls.Add(this.laCreatedBy);
            this.tabPage2.Controls.Add(this.labelCreatedBy);
            this.tabPage2.Controls.Add(this.laDate);
            this.tabPage2.Controls.Add(this.laid);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Gendor);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(830, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Info";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(197, 132);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(170, 24);
            this.cbLicenseClass.TabIndex = 39;
            // 
            // laFees
            // 
            this.laFees.AutoSize = true;
            this.laFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laFees.ForeColor = System.Drawing.Color.Red;
            this.laFees.Location = new System.Drawing.Point(190, 175);
            this.laFees.Name = "laFees";
            this.laFees.Size = new System.Drawing.Size(35, 18);
            this.laFees.TabIndex = 38;
            this.laFees.Text = "???";
            // 
            // laCreatedBy
            // 
            this.laCreatedBy.AutoSize = true;
            this.laCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.laCreatedBy.Location = new System.Drawing.Point(190, 216);
            this.laCreatedBy.Name = "laCreatedBy";
            this.laCreatedBy.Size = new System.Drawing.Size(35, 18);
            this.laCreatedBy.TabIndex = 37;
            this.laCreatedBy.Text = "???";
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreatedBy.Location = new System.Drawing.Point(41, 216);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(96, 18);
            this.labelCreatedBy.TabIndex = 36;
            this.labelCreatedBy.Text = "CreatedBy :";
            // 
            // laDate
            // 
            this.laDate.AutoSize = true;
            this.laDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDate.Location = new System.Drawing.Point(208, 89);
            this.laDate.Name = "laDate";
            this.laDate.Size = new System.Drawing.Size(35, 18);
            this.laDate.TabIndex = 35;
            this.laDate.Text = "???";
            // 
            // laid
            // 
            this.laid.AutoSize = true;
            this.laid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laid.Location = new System.Drawing.Point(209, 57);
            this.laid.Name = "laid";
            this.laid.Size = new System.Drawing.Size(35, 18);
            this.laid.TabIndex = 31;
            this.laid.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Application Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "License Class :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Application Fees :";
            // 
            // Gendor
            // 
            this.Gendor.AutoSize = true;
            this.Gendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gendor.Location = new System.Drawing.Point(35, 59);
            this.Gendor.Name = "Gendor";
            this.Gendor.Size = new System.Drawing.Size(147, 18);
            this.Gendor.TabIndex = 26;
            this.Gendor.Text = "D.LApplication ID :";
            // 
            // butNext
            // 
            this.butNext.BackColor = System.Drawing.Color.IndianRed;
            this.butNext.Location = new System.Drawing.Point(718, 415);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(75, 23);
            this.butNext.TabIndex = 7;
            this.butNext.Text = "Next";
            this.butNext.UseVisualStyleBackColor = false;
//            this.butNext.Click += new System.EventHandler(this.butNext_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(13, 426);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
           // this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(347, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 16);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "label1";
            // 
            // NewLocalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butNext);
            this.Controls.Add(this.tabControl1);
            this.Name = "NewLocalDrivingApplication";
            this.Text = "NewLocalDrivingApplication";
            this.Load += new System.EventHandler(this.NewLocalDrivingApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FilterPersonInformation filterPersonInformation1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label laid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Gendor;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label laDate;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label laFees;
        private System.Windows.Forms.Label laCreatedBy;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.Label lblTitle;
    }
}