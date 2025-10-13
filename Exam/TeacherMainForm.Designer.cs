namespace Exam
{
    partial class TeacherMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblClasses;
        private DataGridView dgvClasses;
        private Button btnAddClass, btnEditClass, btnDeleteClass, btnLogout, btnManageQuestions, btnTeacherExamForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblClasses = new Label();
            this.dgvClasses = new DataGridView();
            this.btnAddClass = new Button();
            this.btnEditClass = new Button();
            this.btnDeleteClass = new Button();
            this.btnLogout = new Button();
            this.btnManageQuestions = new Button();
            this.btnTeacherExamForm = new Button();

            // lblClasses
            this.lblClasses.Text = "Your Classes:";
            this.lblClasses.Location = new System.Drawing.Point(20, 20);
            this.lblClasses.AutoSize = true;


            this.btnTeacherExamForm.Text = "Manage Exam";
            this.btnTeacherExamForm.Location = new System.Drawing.Point(540, 250);
            this.btnTeacherExamForm.Click += (s, e) => {
                var qForm = new TeacherExamForm(_currentTeacher);
                qForm.ShowDialog();
            };
            this.btnManageQuestions.Text = "Manage Questions";
            this.btnManageQuestions.Location = new System.Drawing.Point(540, 210);
            this.btnManageQuestions.Click += (s, e) => {
                var qForm = new QuestionManagerForm(_currentTeacher);
                qForm.ShowDialog();
            };

            // dgvClasses
            this.dgvClasses.Location = new System.Drawing.Point(20, 50);
            this.dgvClasses.Size = new System.Drawing.Size(500, 200);
            this.dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.MultiSelect = false;

            // btnAddClass
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.Location = new System.Drawing.Point(540, 50);
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);

            // btnEditClass
            this.btnEditClass.Text = "Edit Class";
            this.btnEditClass.Location = new System.Drawing.Point(540, 90);
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);

            // btnDeleteClass
            this.btnDeleteClass.Text = "Delete Class";
            this.btnDeleteClass.Location = new System.Drawing.Point(540, 130);
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Location = new System.Drawing.Point(540, 170);
            this.btnLogout.Click += (s, e) => { this.Close(); Application.Restart(); };

            // Form
            this.ClientSize = new System.Drawing.Size(680, 280);
            this.Controls.Add(lblClasses);
            this.Controls.Add(dgvClasses);
            this.Controls.Add(btnAddClass);
            this.Controls.Add(btnEditClass);
            this.Controls.Add(btnDeleteClass);
            this.Controls.Add(btnLogout);
            this.Controls.Add(btnManageQuestions);
            this.Controls.Add(btnTeacherExamForm);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Teacher Dashboard";
        }
    }
}
