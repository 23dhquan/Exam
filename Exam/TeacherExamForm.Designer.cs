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
            dgvExams = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnActivate = new Button();

            SuspendLayout();

            // 
            // dgvExams
            // 
            dgvExams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExams.Location = new System.Drawing.Point(40, 40);
            dgvExams.Size = new System.Drawing.Size(850, 600);
            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExams.MultiSelect = false;
            dgvExams.ReadOnly = true;
            dgvExams.RowHeadersVisible = false;
            dgvExams.AllowUserToAddRows = false;
            dgvExams.AllowUserToDeleteRows = false;

            // 
            // Buttons
            // 
            int btnWidth = 250;
            int btnHeight = 50;
            int btnX = 920;
            int spacing = 20;
            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            btnAdd.Text = "➕ Add Exam";
            btnAdd.Font = btnFont;
            btnAdd.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnAdd.Location = new System.Drawing.Point(btnX, 60);
            btnAdd.BackColor = System.Drawing.Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Click += btnAdd_Click;

            btnEdit.Text = "✏️ Edit Exam";
            btnEdit.Font = btnFont;
            btnEdit.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnEdit.Location = new System.Drawing.Point(btnX, 60 + (btnHeight + spacing) * 1);
            btnEdit.BackColor = System.Drawing.Color.LightSkyBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Click += btnEdit_Click;

            btnDelete.Text = "🗑️ Delete Exam";
            btnDelete.Font = btnFont;
            btnDelete.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnDelete.Location = new System.Drawing.Point(btnX, 60 + (btnHeight + spacing) * 2);
            btnDelete.BackColor = System.Drawing.Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Click += btnDelete_Click;

            btnActivate.Text = "⚙️ Activate / Deactivate";
            btnActivate.Font = btnFont;
            btnActivate.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnActivate.Location = new System.Drawing.Point(btnX, 60 + (btnHeight + spacing) * 3);
            btnActivate.BackColor = System.Drawing.Color.Khaki;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Click += btnActivate_Click;

            // 
            // TeacherExamForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1230, 720);
            Controls.Add(dgvExams);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnActivate);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "📚 Manage Exams";
            ResumeLayout(false);
        }
    }
}
