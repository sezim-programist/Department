
namespace Отдел_кадров.WinForm
{
    partial class AddEditStaffForm
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
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtHire = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtBrith = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDismiss = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRegistrationAdress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEducation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRegistrationCity = new System.Windows.Forms.TextBox();
            this.comboPosition = new System.Windows.Forms.ComboBox();
            this.comboBranches = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFIO
            // 
            this.txtFIO.Location = new System.Drawing.Point(15, 30);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(224, 20);
            this.txtFIO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ф.И.О";
            // 
            // dtHire
            // 
            this.dtHire.Location = new System.Drawing.Point(332, 233);
            this.dtHire.Name = "dtHire";
            this.dtHire.Size = new System.Drawing.Size(224, 20);
            this.dtHire.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(328, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата принятия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(328, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Должность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(328, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Филиал";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата рождения";
            // 
            // dtBrith
            // 
            this.dtBrith.Location = new System.Drawing.Point(16, 94);
            this.dtBrith.Name = "dtBrith";
            this.dtBrith.Size = new System.Drawing.Size(224, 20);
            this.dtBrith.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(327, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Дата увольнения";
            // 
            // dtDismiss
            // 
            this.dtDismiss.Location = new System.Drawing.Point(332, 305);
            this.dtDismiss.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtDismiss.Name = "dtDismiss";
            this.dtDismiss.Size = new System.Drawing.Size(224, 20);
            this.dtDismiss.TabIndex = 10;
            this.dtDismiss.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtDismiss_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(328, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Отдел";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(332, 30);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(224, 20);
            this.txtDepartment.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Адрес прописки";
            // 
            // txtRegistrationAdress
            // 
            this.txtRegistrationAdress.Location = new System.Drawing.Point(16, 233);
            this.txtRegistrationAdress.Name = "txtRegistrationAdress";
            this.txtRegistrationAdress.Size = new System.Drawing.Size(223, 20);
            this.txtRegistrationAdress.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Образование";
            // 
            // txtEducation
            // 
            this.txtEducation.Location = new System.Drawing.Point(15, 305);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(225, 20);
            this.txtEducation.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Город прописки";
            // 
            // txtRegistrationCity
            // 
            this.txtRegistrationCity.Location = new System.Drawing.Point(15, 169);
            this.txtRegistrationCity.Name = "txtRegistrationCity";
            this.txtRegistrationCity.Size = new System.Drawing.Size(224, 20);
            this.txtRegistrationCity.TabIndex = 20;
            // 
            // comboPosition
            // 
            this.comboPosition.FormattingEnabled = true;
            this.comboPosition.Location = new System.Drawing.Point(332, 93);
            this.comboPosition.Name = "comboPosition";
            this.comboPosition.Size = new System.Drawing.Size(224, 21);
            this.comboPosition.TabIndex = 22;
            // 
            // comboBranches
            // 
            this.comboBranches.FormattingEnabled = true;
            this.comboBranches.Location = new System.Drawing.Point(331, 168);
            this.comboBranches.Name = "comboBranches";
            this.comboBranches.Size = new System.Drawing.Size(224, 21);
            this.comboBranches.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 42);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(483, 359);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(72, 42);
            this.BtnExit.TabIndex = 25;
            this.BtnExit.Text = "Отмена";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // AddEditStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(576, 408);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboBranches);
            this.Controls.Add(this.comboPosition);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRegistrationCity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEducation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRegistrationAdress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtDismiss);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtBrith);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtHire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFIO);
            this.MaximizeBox = false;
            this.Name = "AddEditStaffForm";
            this.Text = "Окно добавления и редактирования  информации о сотруднике";
            this.Load += new System.EventHandler(this.AddEditStaffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtHire;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtBrith;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDismiss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRegistrationAdress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEducation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRegistrationCity;
        private System.Windows.Forms.ComboBox comboPosition;
        private System.Windows.Forms.ComboBox comboBranches;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnExit;
    }
}