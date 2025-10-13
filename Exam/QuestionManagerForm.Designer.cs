namespace Exam
{
    partial class QuestionManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvQuestions;
        private Button btnAdd, btnEdit, btnDelete, btnImportExcel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvQuestions = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnImportExcel = new Button();

            // dgvQuestions
            this.dgvQuestions.Location = new System.Drawing.Point(20, 20);
            this.dgvQuestions.Size = new System.Drawing.Size(600, 250);
            this.dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.MultiSelect = false;

            // btnAdd
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(640, 20);

            // btnEdit
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(640, 60);

            // btnDelete
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(640, 100);

            // btnImportExcel
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.Location = new System.Drawing.Point(640, 140);
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(780, 300);
            this.Controls.Add(dgvQuestions);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnImportExcel);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Manage Questions";
        }
    }
}
