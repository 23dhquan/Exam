using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    partial class TeacherMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblClasses;
        private Guna2DataGridView dgvClasses;
        private Guna2Button btnAddClass, btnEditClass, btnDeleteClass, btnLogout, btnManageQuestions, btnTeacherExamForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblClasses = new Guna2HtmlLabel();
            this.dgvClasses = new Guna2DataGridView();
            this.btnAddClass = new Guna2Button();
            this.btnEditClass = new Guna2Button();
            this.btnDeleteClass = new Guna2Button();
            this.btnLogout = new Guna2Button();
            this.btnManageQuestions = new Guna2Button();
            this.btnTeacherExamForm = new Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();

            // lblClasses
            this.lblClasses.Text = "📘 Your Classes";
            this.lblClasses.Location = new Point(20, 15);
            this.lblClasses.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblClasses.ForeColor = Color.DodgerBlue;
            this.lblClasses.AutoSize = true;

            // dgvClasses
            this.dgvClasses.Location = new Point(20, 60);
            this.dgvClasses.Size = new Size(900, 600);
            this.dgvClasses.BorderStyle = BorderStyle.None;
            this.dgvClasses.GridColor = Color.LightGray;
            this.dgvClasses.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.dgvClasses.ThemeStyle.HeaderStyle.BackColor = Color.DodgerBlue;
            this.dgvClasses.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            this.dgvClasses.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvClasses.ThemeStyle.RowsStyle.BackColor = Color.White;
            this.dgvClasses.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            this.dgvClasses.ThemeStyle.RowsStyle.SelectionBackColor = Color.AliceBlue;
            this.dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.MultiSelect = false;

            // Button common style
            int btnWidth = 180;
            int btnHeight = 45;
            int btnX = 950;
            int y = 100;

            Font btnFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            // btnAddClass
            this.btnAddClass.Text = "➕ Add Class";
            this.btnAddClass.Location = new Point(btnX, y);
            this.btnAddClass.Size = new Size(btnWidth, btnHeight);
            this.btnAddClass.FillColor = Color.MediumSeaGreen;
            this.btnAddClass.Font = btnFont;
            this.btnAddClass.BorderRadius = 8;
            this.btnAddClass.Click += new EventHandler(this.btnAddClass_Click);

            // btnEditClass
            y += 60;
            this.btnEditClass.Text = "✏️ Edit Class";
            this.btnEditClass.Location = new Point(btnX, y);
            this.btnEditClass.Size = new Size(btnWidth, btnHeight);
            this.btnEditClass.FillColor = Color.Orange;
            this.btnEditClass.Font = btnFont;
            this.btnEditClass.BorderRadius = 8;
            this.btnEditClass.Click += new EventHandler(this.btnEditClass_Click);

            // btnDeleteClass
            y += 60;
            this.btnDeleteClass.Text = "🗑 Delete Class";
            this.btnDeleteClass.Location = new Point(btnX, y);
            this.btnDeleteClass.Size = new Size(btnWidth, btnHeight);
            this.btnDeleteClass.FillColor = Color.IndianRed;
            this.btnDeleteClass.Font = btnFont;
            this.btnDeleteClass.BorderRadius = 8;
            this.btnDeleteClass.Click += new EventHandler(this.btnDeleteClass_Click);

            // btnManageQuestions
            y += 60;
            this.btnManageQuestions.Text = "Manage Questions";
            this.btnManageQuestions.Location = new Point(btnX, y);
            this.btnManageQuestions.Size = new Size(btnWidth, btnHeight);
            this.btnManageQuestions.FillColor = Color.RoyalBlue;
            this.btnManageQuestions.Font = btnFont;
            this.btnManageQuestions.BorderRadius = 8;
            this.btnManageQuestions.Click += (s, e) => {
                var qForm = new QuestionManagerForm(_currentTeacher);
                qForm.ShowDialog();
            };

            // btnTeacherExamForm
            y += 60;
            this.btnTeacherExamForm.Text = "📝 Manage Exams";
            this.btnTeacherExamForm.Location = new Point(btnX, y);
            this.btnTeacherExamForm.Size = new Size(btnWidth, btnHeight);
            this.btnTeacherExamForm.FillColor = Color.MediumPurple;
            this.btnTeacherExamForm.Font = btnFont;
            this.btnTeacherExamForm.BorderRadius = 8;
            this.btnTeacherExamForm.Click += (s, e) => {
                var qForm = new TeacherExamForm(_currentTeacher);
                qForm.ShowDialog();
            };

            // btnLogout
            y += 60;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.Location = new Point(btnX, y);
            this.btnLogout.Size = new Size(btnWidth, btnHeight);
            this.btnLogout.FillColor = Color.Gray;
            this.btnLogout.Font = btnFont;
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.Click += (s, e) => { this.Close(); Application.Restart(); };

            // TeacherMainForm
            this.ClientSize = new Size(1230, 720);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnEditClass);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageQuestions);
            this.Controls.Add(this.btnTeacherExamForm);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Teacher Dashboard (Guna UI2)";
            this.BackColor = Color.White;

            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
