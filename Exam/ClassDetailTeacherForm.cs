using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;
using OfficeOpenXml;  // Cần cài NuGet: EPPlus
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Exam
{
    public partial class ClassDetailTeacherForm : Form
    {
        private ExamSystemContext _db = new ExamSystemContext();
        private int _classId;

        public ClassDetailTeacherForm(int classId)
        {
            _classId = classId;
            InitializeComponent();
            LoadDetails();
        }

        private void LoadDetails()
        {
            var cls = _db.Classes.FirstOrDefault(c => c.Id == _classId);
            if (cls == null) return;

            lblClassName.Text = $"{cls.Name} ({cls.Code})";
            txtDescription.Text = cls.Description ?? "(No description)";

            // Load students
            var students = _db.ClassStudents
                .Where(cs => cs.ClassId == _classId)
                .Select(cs => new { cs.Student.Id, cs.Student.Name, cs.Student.Email })
                .ToList();
            dgvStudents.DataSource = students;
            dgvStudents.Columns["Id"].Visible = false;

            // Load exams
            var exams = _db.Exams
                .Where(e => e.ClassId == _classId)
                .Select(e => new { e.Id, e.Title, e.Description, e.CreatedAt })
                .ToList();
            dgvExams.DataSource = exams;
            dgvExams.Columns["Id"].Visible = false;

            // Load scores table
            LoadScores();
        }

        private void LoadScores()
        {
            var exams = _db.Exams.Where(e => e.ClassId == _classId).ToList();
            var students = _db.ClassStudents
                .Where(cs => cs.ClassId == _classId)
                .Select(cs => cs.Student)
                .ToList();

            var dt = new DataTable();
            dt.Columns.Add("Student");
            foreach (var ex in exams)
                dt.Columns.Add(ex.Title);

            foreach (var st in students)
            {
                var row = dt.NewRow();
                row["Student"] = st.Name;

                foreach (var ex in exams)
                {
                    var score = _db.Submissions
                        .Where(s => s.ExamId == ex.Id && s.StudentId == st.Id)
                        .Select(s => s.TotalScore)
                        .FirstOrDefault();
                    row[ex.Title] = score == 0 ? "-" : score.ToString("0.##");
                }

                dt.Rows.Add(row);
            }

            dgvScores.DataSource = dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files|*.csv",
                FileName = "ClassScores.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using var sw = new StreamWriter(sfd.FileName);

                // Ghi tiêu đề
                for (int i = 0; i < dgvScores.Columns.Count; i++)
                {
                    sw.Write(dgvScores.Columns[i].HeaderText);
                    if (i < dgvScores.Columns.Count - 1)
                        sw.Write(",");
                }
                sw.WriteLine();

                // Ghi dữ liệu
                foreach (DataGridViewRow row in dgvScores.Rows)
                {
                    for (int i = 0; i < dgvScores.Columns.Count; i++)
                    {
                        sw.Write(row.Cells[i].Value?.ToString());
                        if (i < dgvScores.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();
                }

                sw.Close();
                MessageBox.Show("✅ Xuất file CSV thành công!");
            }
        }

    }
}
