using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exam.Forms
{
    partial class ExamPopupForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblDescription;
        private Label lblDuration;
        private Label lblClass;

        private TextBox txtTitle;
        private TextBox txtDescription;
        private NumericUpDown numDuration;
        private ComboBox cbClass;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDescription = new Label();
            lblDuration = new Label();
            lblClass = new Label();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            numDuration = new NumericUpDown();
            cbClass = new ComboBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F);
            lblTitle.Location = new Point(40, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(92, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Exam Title:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(40, 72);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Description:";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 10F);
            lblDuration.Location = new Point(40, 170);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(157, 23);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Duration (minutes):";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI", 10F);
            lblClass.Location = new Point(40, 210);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(52, 23);
            lblClass.TabIndex = 3;
            lblClass.Text = "Class:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.Location = new Point(198, 29);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 30);
            txtTitle.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(198, 69);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 80);
            txtDescription.TabIndex = 5;
            // 
            // numDuration
            // 
            numDuration.Font = new Font("Segoe UI", 10F);
            numDuration.Location = new Point(198, 167);
            numDuration.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(120, 30);
            numDuration.TabIndex = 6;
            numDuration.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // cbClass
            // 
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClass.Font = new Font("Segoe UI", 10F);
            cbClass.Location = new Point(198, 207);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(300, 31);
            cbClass.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(94, 148, 255);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(198, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 8;
            btnSave.Text = "💾 Save Exam";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ExamPopupForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(540, 330);
            Controls.Add(lblTitle);
            Controls.Add(lblDescription);
            Controls.Add(lblDuration);
            Controls.Add(lblClass);
            Controls.Add(txtTitle);
            Controls.Add(txtDescription);
            Controls.Add(numDuration);
            Controls.Add(cbClass);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExamPopupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exam Form";
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
