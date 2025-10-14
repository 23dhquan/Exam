using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class TakeExamForm : Form
    {
        private User _student;
        private Exam.Models.Exam _exam;
        private ExamSystemContext _db = new ExamSystemContext();
        private List<Question> _questions;
        private Dictionary<int, string> _answers = new Dictionary<int, string>();
        private int _timeLeft; // giây còn lại

        public TakeExamForm(User student, Exam.Models.Exam exam)
        {
            _student = student;
            _exam = exam;
            InitializeComponent();
            LoadExam();
        }

        private void LoadExam()
        {
            // Kiểm tra thời gian làm bài
            if (_exam.StartTime.HasValue && DateTime.Now < _exam.StartTime.Value)
            {
                MessageBox.Show("Chưa đến thời gian làm bài.");
                Close();
                return;
            }
            if (_exam.EndTime.HasValue && DateTime.Now > _exam.EndTime.Value)
            {
                MessageBox.Show("Bài thi đã hết hạn.");
                Close();
                return;
            }

            _questions = _db.Questions
                .Where(q => q.ExamId == _exam.Id)
                .OrderBy(q => Guid.NewGuid()) // đảo thứ tự
                .ToList();

            pnlQuestions.Controls.Clear();
            int y = 20;

            foreach (var q in _questions)
            {
                // Panel riêng cho câu hỏi
                var questionPanel = new Panel
                {
                    Location = new Point(20, y),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                // ==== Câu hỏi chính ====
                var lbl = new Label
                {
                    Text = $"Câu {(_questions.IndexOf(q) + 1)}: {q.Content}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold)
                };
                questionPanel.Controls.Add(lbl);
                int ry = lbl.Bottom + 10;

                // Hình ảnh câu hỏi nếu có
                if (!string.IsNullOrEmpty(q.ContentImage) && File.Exists(q.ContentImage))
                {
                    var pic = new PictureBox
                    {
                        Image = Image.FromFile(q.ContentImage),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(300, 200),
                        Location = new Point(20, ry)
                    };
                    questionPanel.Controls.Add(pic);
                    ry += pic.Height + 10;
                }

                // ==== Đáp án ====
                string?[] optionTexts = { q.OptionAText, q.OptionBText, q.OptionCText, q.OptionDText };
                string?[] optionImages = { q.OptionAImage, q.OptionBImage, q.OptionCImage, q.OptionDImage };
                char[] keys = { 'A', 'B', 'C', 'D' };

                for (int i = 0; i < 4; i++)
                {
                    var rdo = new RadioButton
                    {
                        Text = !string.IsNullOrEmpty(optionTexts[i]) ? $"{keys[i]}. {optionTexts[i]}" : $"{keys[i]}.",
                        Tag = keys[i].ToString(),
                        Location = new Point(20, ry),
                        AutoSize = true
                    };
                    rdo.CheckedChanged += (s, e) =>
                    {
                        var r = s as RadioButton;
                        if (r.Checked) _answers[q.Id] = r.Tag.ToString();
                    };
                    questionPanel.Controls.Add(rdo);
                    ry += rdo.Height + 5;

                    if (!string.IsNullOrEmpty(optionImages[i]) && File.Exists(optionImages[i]))
                    {
                        var picOpt = new PictureBox
                        {
                            Image = Image.FromFile(optionImages[i]),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 150),
                            Location = new Point(40, ry)
                        };
                        questionPanel.Controls.Add(picOpt);
                        ry += picOpt.Height + 5;
                    }
                }

                pnlQuestions.Controls.Add(questionPanel);
                y += questionPanel.Height + 15;
            }

            // Thời gian thi
            _timeLeft = (_exam.Duration ?? 30) * 60;
            timer1.Start();
            UpdateTimerLabel();
        }

        private void UpdateTimerLabel()
        {
            int minutes = _timeLeft / 60;
            int seconds = _timeLeft % 60;
            lblTimer.Text = $"Thời gian còn lại: {minutes:D2}:{seconds:D2}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _timeLeft--;
            UpdateTimerLabel();
            if (_timeLeft <= 0)
            {
                SubmitExam();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn nộp bài?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                SubmitExam();
            }
        }

        private void SubmitExam()
        {
            timer1.Stop();

            int correctCount = 0;
            int total = _questions.Count;

            var submission = new Submission
            {
                ExamId = _exam.Id,
                StudentId = _student.Id,
                SubmittedAt = DateTime.Now,
                TotalScore = 0
            };
            _db.Submissions.Add(submission);
            _db.SaveChanges();

            foreach (var q in _questions)
            {
                string selected = _answers.ContainsKey(q.Id) ? _answers[q.Id] : null;
                bool isCorrect = (selected != null && selected == q.CorrectOption);

                if (isCorrect) correctCount++;

                var sa = new SubmissionAnswer
                {
                    SubmissionId = submission.Id,
                    QuestionId = q.Id,
                    ChosenOption = selected,
                    IsCorrect = isCorrect
                };
                _db.SubmissionAnswers.Add(sa);
            }

            double score = total > 0 ? (correctCount * 10.0 / total) : 0;
            submission.TotalScore = (float)score;
            _db.SaveChanges();

            MessageBox.Show($"Bạn trả lời đúng {correctCount}/{total} câu.\nĐiểm: {score:0.00}", "Kết quả");

            this.Close();
        }
    }
}
