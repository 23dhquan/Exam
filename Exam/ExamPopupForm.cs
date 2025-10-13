using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;   // dùng Exam.Models.Exam

namespace Exam.Forms   // đổi namespace form cho khác
{
    public partial class ExamPopupForm : Form
    {
        private readonly User _teacher;
        private Exam.Models.Exam? _exam;  // null = add, có dữ liệu = edit
        private readonly ExamSystemContext _db = new ExamSystemContext();

        public ExamPopupForm(User teacher, Exam.Models.Exam? exam = null)
        {
            _teacher = teacher;
            _exam = exam;
            InitializeComponent();
            LoadClasses();

            if (_exam is not null)
            {
                // Edit mode
                txtTitle.Text = _exam.Title;
                txtDescription.Text = _exam.Description ?? "";
                numDuration.Value = _exam.Duration ?? 60;
                cbClass.SelectedValue = _exam.ClassId;
            }
        }

        private void LoadClasses()
        {
            var classes = _db.Classes
                .Where(c => c.TeacherId == _teacher.Id)
                .Select(c => new { c.Id, c.Name })
                .ToList();

            cbClass.DataSource = classes;
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề.");
                return;
            }

            if (_exam is null)
            {
                // Add new exam
                int selectedValue = (int)cbClass.SelectedValue;
                var newExam = new Exam.Models.Exam
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    TeacherId = _teacher.Id,
                    ClassId = selectedValue,
                    Duration = (int)numDuration.Value,
                    is_active = 0,
                    CreatedAt = DateTime.Now
                };

                _db.Exams.Add(newExam);
            }
            else
            {
                // Edit existing exam
                _exam.Title = txtTitle.Text.Trim();
                _exam.Description = txtDescription.Text.Trim();
                _exam.ClassId = (int)cbClass.SelectedValue;
                _exam.Duration = (int)numDuration.Value;
            }

            _db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
