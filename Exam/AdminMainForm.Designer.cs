using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Exam
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel sidebarPanel;
        private Guna2Button btnUsers, btnClasses, btnExams, btnLogout;
        private DataGridView dgvMain;

        // CRUD Panels
        private Panel crudUsersPanel, crudClassesPanel, crudExamsPanel;

        // Users controls
        private TextBox txtUserName, txtUserEmail;
        private ComboBox cmbUserRole;
        private Guna2Button btnSaveUser, btnDeleteUser, btnClearUser;

        // Classes controls
        private TextBox txtClassName, txtClassCode;
        private ComboBox cmbClassTeacher;
        private Guna2Button btnSaveClass, btnDeleteClass, btnClearClass;

        // Exams controls
        private TextBox txtExamTitle, txtExamDescription;
        private ComboBox cmbExamTeacher, cmbExamClass;
        private DateTimePicker dtpExamStart, dtpExamEnd;
        private NumericUpDown nudExamDuration;
        private Guna2Button btnSaveExam, btnDeleteExam, btnClearExam;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(1230, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";

            // Sidebar
            sidebarPanel = new Guna2Panel { Dock = DockStyle.Left, Width = 180, FillColor = System.Drawing.Color.FromArgb(30, 30, 30) };
            btnUsers = CreateSidebarButton("Users", 20);
            btnClasses = CreateSidebarButton("Classes", 75);
            btnExams = CreateSidebarButton("Exams", 130);
            btnLogout = CreateSidebarButton("Logout", 185);

            btnUsers.Click += (s, e) => ShowCrudPanel("Users");
            btnClasses.Click += (s, e) => ShowCrudPanel("Classes");
            btnExams.Click += (s, e) => ShowCrudPanel("Exams");
            btnLogout.Click += (s, e) => { this.Close(); Application.Restart(); };

            sidebarPanel.Controls.AddRange(new Control[] { btnUsers, btnClasses, btnExams, btnLogout });
            this.Controls.Add(sidebarPanel);

            // DataGridView
            dgvMain = new DataGridView
            {
                Location = new System.Drawing.Point(200, 20),
                Size = new System.Drawing.Size(700, 680),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = true
            };
            dgvMain.CellClick += DgvMain_CellClick;
            this.Controls.Add(dgvMain);

            // === CRUD USERS ===
            crudUsersPanel = new Panel { Location = new System.Drawing.Point(910, 20), Size = new System.Drawing.Size(300, 680), Visible = false };
            txtUserName = CreateTextBox(crudUsersPanel, "Name:", 10);
            txtUserEmail = CreateTextBox(crudUsersPanel, "Email:", 50);
            cmbUserRole = CreateComboBox(crudUsersPanel, "Role:", 90);
            cmbUserRole.Items.AddRange(new string[] { "student", "teacher", "admin" });

            btnSaveUser = CreateCrudButton("Save", 150, crudUsersPanel);
            btnDeleteUser = CreateCrudButton("Delete", 200, crudUsersPanel);
            btnClearUser = CreateCrudButton("Clear", 250, crudUsersPanel);

            btnSaveUser.Click += BtnSave_Click;
            btnDeleteUser.Click += BtnDelete_Click;
            btnClearUser.Click += BtnClear_Click;

            this.Controls.Add(crudUsersPanel);

            // === CRUD CLASSES ===
            crudClassesPanel = new Panel { Location = new System.Drawing.Point(910, 20), Size = new System.Drawing.Size(300, 680), Visible = false };
            txtClassName = CreateTextBox(crudClassesPanel, "Class Name:", 10);
            txtClassCode = CreateTextBox(crudClassesPanel, "Code:", 50);
            cmbClassTeacher = CreateComboBox(crudClassesPanel, "Teacher:", 90);

            btnSaveClass = CreateCrudButton("Save", 150, crudClassesPanel);
            btnDeleteClass = CreateCrudButton("Delete", 200, crudClassesPanel);
            btnClearClass = CreateCrudButton("Clear", 250, crudClassesPanel);

            btnSaveClass.Click += BtnSave_Click;
            btnDeleteClass.Click += BtnDelete_Click;
            btnClearClass.Click += BtnClear_Click;

            this.Controls.Add(crudClassesPanel);

            // === CRUD EXAMS ===
            crudExamsPanel = new Panel { Location = new System.Drawing.Point(910, 20), Size = new System.Drawing.Size(300, 680), Visible = false };
            txtExamTitle = CreateTextBox(crudExamsPanel, "Title:", 10);
            txtExamDescription = CreateTextBox(crudExamsPanel, "Description:", 50);
            cmbExamTeacher = CreateComboBox(crudExamsPanel, "Teacher:", 90);
            cmbExamClass = CreateComboBox(crudExamsPanel, "Class:", 130);

            dtpExamStart = new DateTimePicker { Location = new System.Drawing.Point(100, 170), Width = 180 };
            dtpExamEnd = new DateTimePicker { Location = new System.Drawing.Point(100, 210), Width = 180 };
            nudExamDuration = new NumericUpDown { Location = new System.Drawing.Point(100, 250), Width = 100, Maximum = 300, Value = 30 };
            crudExamsPanel.Controls.AddRange(new Control[] {
                new Label { Text = "Start:", Location = new System.Drawing.Point(10,170), AutoSize = true  }, dtpExamStart,
                new Label { Text = "End:", Location = new System.Drawing.Point(10,210), AutoSize = true  }, dtpExamEnd,
                new Label { Text = "Duration:", Location = new System.Drawing.Point(10,250), AutoSize = true}, nudExamDuration
            });

            btnSaveExam = CreateCrudButton("Save", 300, crudExamsPanel);
            btnDeleteExam = CreateCrudButton("Delete", 350, crudExamsPanel);
            btnClearExam = CreateCrudButton("Clear", 400, crudExamsPanel);

            btnSaveExam.Click += BtnSave_Click;
            btnDeleteExam.Click += BtnDelete_Click;
            btnClearExam.Click += BtnClear_Click;

            this.Controls.Add(crudExamsPanel);
        }

        private Guna2Button CreateSidebarButton(string text, int top)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new System.Drawing.Size(160, 45),
                Location = new System.Drawing.Point(10, top),
                FillColor = System.Drawing.Color.FromArgb(45, 45, 45),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };
        }

        private TextBox CreateTextBox(Panel parent, string label, int y)
        {
            parent.Controls.Add(new Label { Text = label, Location = new System.Drawing.Point(10, y), Width = 80 });
            TextBox tb = new TextBox { Location = new System.Drawing.Point(100, y), Width = 180 };
            parent.Controls.Add(tb);
            return tb;
        }

        private ComboBox CreateComboBox(Panel parent, string label, int y)
        {
            parent.Controls.Add(new Label { Text = label, Location = new System.Drawing.Point(10, y), Width = 80 });
            ComboBox cb = new ComboBox { Location = new System.Drawing.Point(100, y), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            parent.Controls.Add(cb);
            return cb;
        }

        private Guna2Button CreateCrudButton(string text, int y, Panel parent)
        {
            var btn = new Guna2Button { Text = text, Location = new System.Drawing.Point(20, y), Size = new System.Drawing.Size(260, 35) };
            parent.Controls.Add(btn);
            return btn;
        }
    }
}
