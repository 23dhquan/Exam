using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;
using Guna.UI2.WinForms;

namespace Exam
{
    public partial class ClassDetailForm : Form
    {
        private User _student;
        private Class _class;
        private ExamSystemContext _db = new ExamSystemContext();

        public ClassDetailForm(User student, Class cls)
        {
            _student = student;
            _class = cls;
            InitializeComponent();
            lblTitle.Text = $"Exams for Class: {_class.Name} ({_class.Code})";
            LoadExams();
        }

        private void LoadExams()
        {
            flowExams.Controls.Clear();

            var exams = _db.Exams
               .Where(e => e.ClassId == _class.Id && e.is_active == 1)
               .ToList();


            foreach (var exam in exams)
            {
                var btnExam = new Guna2Button();
                btnExam.Text = $"{exam.Title}\nDuration: {exam.Duration} mins";
                btnExam.Tag = exam;
                btnExam.Width = 250;
                btnExam.Height = 100;
                btnExam.BorderRadius = 12;
                btnExam.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
                btnExam.FillColor = System.Drawing.Color.SeaGreen;
                btnExam.ForeColor = System.Drawing.Color.White;
                btnExam.Margin = new Padding(20);

                btnExam.Click += BtnExam_Click;

                flowExams.Controls.Add(btnExam);
            }

            if (exams.Count == 0)
            {
                var lbl = new Guna2HtmlLabel();
                lbl.Text = "No exams available for this class.";
                lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Italic);
                lbl.ForeColor = System.Drawing.Color.Gray;
                lbl.AutoSize = false;
                lbl.Size = new System.Drawing.Size(400, 40);
                lbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                lbl.Location = new System.Drawing.Point(400, 200);
                flowExams.Controls.Add(lbl);
            }
        }

       private void BtnExam_Click(object sender, EventArgs e)
{
    var btn = sender as Guna2Button;
    var exam = btn.Tag as Exam.Models.Exam;

    DateTime now = DateTime.Now;

    // Kiểm tra thời gian làm bài
    if (exam.StartTime.HasValue && now < exam.StartTime.Value)
    {
        MessageBox.Show("Chưa đến thời gian làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
    if (exam.EndTime.HasValue && now > exam.EndTime.Value)
    {
        MessageBox.Show("Đã hết hạn làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Kiểm tra thời lượng
    if (!exam.Duration.HasValue || exam.Duration.Value <= 0)
    {
        MessageBox.Show("Đề thi chưa có thời lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Nếu hợp lệ -> mở form làm bài
    var examForm = new TakeExamForm(_student, exam);
    examForm.ShowDialog();
}


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
