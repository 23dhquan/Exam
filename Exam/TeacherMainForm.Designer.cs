using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    partial class TeacherMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblHeader;
        private Guna2DataGridView dgvClasses;
        private Guna2Button btnAddClass, btnEditClass, btnDeleteClass, btnManageQuestions, btnTeacherExamForm, btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHeader = new Guna2HtmlLabel();
            dgvClasses = new Guna2DataGridView();
            btnAddClass = new Guna2Button();
            btnEditClass = new Guna2Button();
            btnDeleteClass = new Guna2Button();
            btnManageQuestions = new Guna2Button();
            btnTeacherExamForm = new Guna2Button();
            btnLogout = new Guna2Button();

            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();

            // =======================
            // LABEL HEADER
            // =======================
            lblHeader.Text = "📘 Your Classes";
            lblHeader.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblHeader.ForeColor = Color.DodgerBlue;
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(40, 20);

            // =======================
            // DATAGRIDVIEW
            // =======================
            dgvClasses.Location = new Point(40, 80);
            dgvClasses.Size = new Size(880, 600);
            dgvClasses.BorderStyle = BorderStyle.None;
            dgvClasses.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvClasses.ThemeStyle.HeaderStyle.BackColor = Color.DodgerBlue;
            dgvClasses.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvClasses.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvClasses.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvClasses.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvClasses.ThemeStyle.RowsStyle.SelectionBackColor = Color.AliceBlue;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.MultiSelect = false;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.AllowUserToDeleteRows = false;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvClasses_CellDoubleClick);


            // =======================
            // BUTTON COMMON STYLE
            // =======================
            int btnX = 960, btnY = 100;
            int btnW = 200, btnH = 50, space = 15;
            Font btnFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            void StyleButton(Guna2Button btn, string text, Color color, EventHandler onClick)
            {
                btn.Text = text;
                btn.Size = new Size(btnW, btnH);
                btn.Location = new Point(btnX, btnY);
                btn.FillColor = color;
                btn.Font = btnFont;
                btn.BorderRadius = 8;
                btn.Click += onClick;
                btnY += btnH + space;
            }

            // =======================
            // BUTTONS
            // =======================
            StyleButton(btnAddClass, "➕ Add Class", Color.MediumSeaGreen, btnAddClass_Click);
            StyleButton(btnEditClass, "✏️ Edit Class", Color.Orange, btnEditClass_Click);
            StyleButton(btnDeleteClass, "🗑 Delete Class", Color.IndianRed, btnDeleteClass_Click);

            StyleButton(btnManageQuestions, "🧠 Manage Questions", Color.RoyalBlue, (s, e) =>
            {
                var qForm = new QuestionManagerForm(_currentTeacher);
                qForm.ShowDialog();
            });

            StyleButton(btnTeacherExamForm, "📝 Manage Exams", Color.MediumPurple, (s, e) =>
            {
                var exForm = new TeacherExamForm(_currentTeacher);
                exForm.ShowDialog();
            });

            StyleButton(btnLogout, "🚪 Logout", Color.Gray, (s, e) =>
            {
                Close();
                Application.Restart();
            });

            // =======================
            // FORM SETTINGS
            // =======================
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 720);
            BackColor = Color.White;
            Controls.Add(lblHeader);
            Controls.Add(dgvClasses);
            Controls.Add(btnAddClass);
            Controls.Add(btnEditClass);
            Controls.Add(btnDeleteClass);
            Controls.Add(btnManageQuestions);
            Controls.Add(btnTeacherExamForm);
            Controls.Add(btnLogout);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Dashboard (Guna UI2)";

            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
