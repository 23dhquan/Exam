namespace Exam
{
    partial class TeacherExamForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvExams;
        private Button btnAdd, btnEdit, btnDelete, btnActivate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvExams = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnActivate = new Button();

            // dgvExams
            this.dgvExams.Location = new System.Drawing.Point(20, 20);
            this.dgvExams.Size = new System.Drawing.Size(600, 250);
            this.dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvExams.MultiSelect = false;

            // btnAdd
            this.btnAdd.Text = "Add Exam";
            this.btnAdd.Location = new System.Drawing.Point(650, 20);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "Edit Exam";
            this.btnEdit.Location = new System.Drawing.Point(650, 60);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Text = "Delete Exam";
            this.btnDelete.Location = new System.Drawing.Point(650, 100);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnActivate
            this.btnActivate.Text = "Activate/Deactivate";
            this.btnActivate.Location = new System.Drawing.Point(650, 140);
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.dgvExams);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnActivate);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Manage Exams";
        }
    }
}