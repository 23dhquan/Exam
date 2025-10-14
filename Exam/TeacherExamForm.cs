using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Forms;
using Exam.Models;

namespace Exam
{
    public partial class TeacherExamForm : Form
    {
        private readonly User _teacher;
        private ExamSystemContext _db = new ExamSystemContext();

        public TeacherExamForm(User teacher)
        {
            _teacher = teacher;
            InitializeComponent();
            LoadExams();
        }

        private void LoadExams()
        {
            dgvExams.DataSource = _db.Exams
                .Where(e => e.TeacherId == _teacher.Id)
                .Select(e => new {
                    e.Id,
                    e.Title,
                    e.Description,
                    e.StartTime,
                    e.EndTime,
                    e.Duration,
                    e.is_active
                })
                .ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var popup = new ExamPopupForm(_teacher);
            popup.ShowDialog();
            LoadExams();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            int id = (int)dgvExams.CurrentRow.Cells["Id"].Value;
            var exam = _db.Exams.Find(id);
            if (exam == null) return;

            var popup = new ExamPopupForm(_teacher, exam);
            popup.ShowDialog();
            LoadExams();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            int id = (int)dgvExams.CurrentRow.Cells["Id"].Value;
            var exam = _db.Exams.Find(id);
            if (exam == null) return;

            if (MessageBox.Show("Delete this exam?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _db.Exams.Remove(exam);
                _db.SaveChanges();
                LoadExams();
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            int id = (int)dgvExams.CurrentRow.Cells["Id"].Value;
            var exam = _db.Exams.Find(id);
            if (exam == null) return;

            exam.is_active = exam.is_active == 1 ? 0 : 1; // Toggle
            if (exam.is_active == 1)
            {
                exam.StartTime = DateTime.Now;
                exam.EndTime = exam.StartTime.Value.AddMinutes(exam.Duration ?? 0);
            }

            _db.SaveChanges();
            LoadExams();
        }
    }
}