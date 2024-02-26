
namespace Отдел_кадров.WinForm
{
    partial class AddEditPositionsForm
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
            this.numericDays = new System.Windows.Forms.NumericUpDown();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.numericExp = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExp)).BeginInit();
            this.SuspendLayout();
            // 
            // numericDays
            // 
            this.numericDays.Location = new System.Drawing.Point(16, 166);
            this.numericDays.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericDays.Name = "numericDays";
            this.numericDays.Size = new System.Drawing.Size(224, 20);
            this.numericDays.TabIndex = 54;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(219, 234);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(72, 42);
            this.BtnClose.TabIndex = 53;
            this.BtnClose.Text = "Отмена";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(116, 234);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(72, 42);
            this.BtnSave.TabIndex = 52;
            this.BtnSave.Text = "Сохранить";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 20);
            this.label11.TabIndex = 51;
            this.label11.Text = "Требования к стажу";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(12, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(248, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "Дополнительные дни к отпуску";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Название должности";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(15, 30);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(224, 20);
            this.txtPost.TabIndex = 45;
            // 
            // numericExp
            // 
            this.numericExp.Location = new System.Drawing.Point(16, 96);
            this.numericExp.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericExp.Name = "numericExp";
            this.numericExp.Size = new System.Drawing.Size(224, 20);
            this.numericExp.TabIndex = 55;
            // 
            // AddEditPositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 293);
            this.Controls.Add(this.numericExp);
            this.Controls.Add(this.numericDays);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPost);
            this.Name = "AddEditPositionsForm";
            this.Text = "Добавить изменить должность";
            this.Load += new System.EventHandler(this.AddEditPositionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericDays;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.NumericUpDown numericExp;
    }
}