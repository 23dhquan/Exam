using Exam.Models;
using ExcelDataReader;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam
{
    public partial class ImportQuestionsForm : Form
    {
        private readonly User _teacher;
        private ExamSystemContext _db = new ExamSystemContext();
        private string _filePath = "";

        public ImportQuestionsForm(User teacher)
        {
            _teacher = teacher;
            InitializeComponent();
            LoadExams();
        }

        private void LoadExams()
        {
            var exams = _db.Exams
                           .Where(e => e.TeacherId == _teacher.Id)
                           .Select(e => new { e.Id, e.Title })
                           .ToList();

            cbExam.DataSource = exams;
            cbExam.DisplayMember = "Title";
            cbExam.ValueMember = "Id";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _filePath = ofd.FileName;
                    lblFile.Text = _filePath;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                MessageBox.Show("Please select an Excel file!");
                return;
            }

            if (cbExam.SelectedValue == null)
            {
                MessageBox.Show("Please select an exam!");
                return;
            }

            int examId = (int)cbExam.SelectedValue;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(_filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0]; // sheet đầu tiên

                for (int i = 1; i < table.Rows.Count; i++) // bỏ dòng tiêu đề
                {
                    var row = table.Rows[i];
                    if (row == null || string.IsNullOrWhiteSpace(row[0]?.ToString())) continue;

                    var q = new Question
                    {
                        TeacherId = _teacher.Id,
                        ExamId = examId,
                        Content = row[0]?.ToString(),
                        OptionAText = row[1]?.ToString(),
                        OptionBText = row[2]?.ToString(),
                        OptionCText = row[3]?.ToString(),
                        OptionDText = row[4]?.ToString(),
                        CorrectOption = row[5]?.ToString() ?? "A",
                        Score = float.TryParse(row[6]?.ToString(), out var sc) ? sc : 1
                    };
                    _db.Questions.Add(q);
                }
                _db.SaveChanges();
            }

            MessageBox.Show("Imported questions successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
