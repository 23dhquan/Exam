using Exam.Models;
using ExcelDataReader; // cần cài package ExcelDataReader + ExcelDataReader.DataSet
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam
{
    public partial class QuestionManagerForm : Form
    {
        private User _teacher;
        private ExamSystemContext _db = new ExamSystemContext();

        public QuestionManagerForm(User teacher)
        {
            _teacher = teacher;
            InitializeComponent();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            dgvQuestions.DataSource = _db.Questions
                                         .Where(q => q.TeacherId == _teacher.Id)
                                         .Select(q => new {
                                             q.Id,
                                             q.Content,
                                             q.OptionAText,
                                             q.OptionBText,
                                             q.OptionCText,
                                             q.OptionDText,
                                             q.CorrectOption,
                                             q.Score
                                         })
                                         .ToList();
        }

        //private void btnImportExcel_Click(object sender, EventArgs e)
        //{
        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx" })
        //    {
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            using (var stream = System.IO.File.Open(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        //            {
        //                using (var reader = ExcelReaderFactory.CreateReader(stream))
        //                {
        //                    var result = reader.AsDataSet();
        //                    var table = result.Tables[0]; // sheet đầu tiên

        //                    for (int i = 1; i < table.Rows.Count; i++) // bỏ dòng tiêu đề
        //                    {
        //                        var row = table.Rows[i];
        //                        var q = new Question
        //                        {
        //                            TeacherId = _teacher.Id,
        //                            ExamId = 1, // TODO: map với Exam hiện tại
        //                            Content = row[0]?.ToString(),
        //                            OptionAText = row[1]?.ToString(),
        //                            OptionBText = row[2]?.ToString(),
        //                            OptionCText = row[3]?.ToString(),
        //                            OptionDText = row[4]?.ToString(),
        //                            CorrectOption = row[5]?.ToString() ?? "A",
        //                            Score = float.TryParse(row[6]?.ToString(), out var sc) ? sc : 1
        //                        };
        //                        _db.Questions.Add(q);
        //                    }
        //                    _db.SaveChanges();
        //                }
        //            }
        //            MessageBox.Show("Imported questions successfully!");
        //            LoadQuestions();
        //        }
        //    }
        //}
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            var importForm = new ImportQuestionsForm(_teacher);
            if (importForm.ShowDialog() == DialogResult.OK)
            {
                LoadQuestions(); // reload sau khi import
            }
        }

    }
}
