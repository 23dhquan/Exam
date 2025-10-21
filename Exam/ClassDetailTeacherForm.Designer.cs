using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    partial class ClassDetailTeacherForm
    {
        private Label lblClassName;
        private TextBox txtDescription;
        private DataGridView dgvStudents, dgvExams, dgvScores;
        private Button btnExport;

        private void InitializeComponent()
        {
            lblClassName = new Label();
            txtDescription = new TextBox();
            dgvStudents = new DataGridView();
            dgvExams = new DataGridView();
            dgvScores = new DataGridView();
            btnExport = new Button();

            SuspendLayout();

            lblClassName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblClassName.Location = new Point(20, 15);
            lblClassName.AutoSize = true;

            txtDescription.Location = new Point(25, 55);
            txtDescription.Multiline = true;
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(800, 50);

            dgvStudents.Location = new Point(25, 120);
            dgvStudents.Size = new Size(350, 200);

            dgvExams.Location = new Point(400, 120);
            dgvExams.Size = new Size(420, 200);

            dgvScores.Location = new Point(25, 340);
            dgvScores.Size = new Size(795, 280);

            btnExport.Text = "📤 Export Excel";
            btnExport.Location = new Point(680, 630);
            btnExport.Size = new Size(140, 40);
            btnExport.Click += btnExport_Click;

            ClientSize = new Size(850, 700);
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Class Details";

            Controls.Add(lblClassName);
            Controls.Add(txtDescription);
            Controls.Add(dgvStudents);
            Controls.Add(dgvExams);
            Controls.Add(dgvScores);
            Controls.Add(btnExport);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
