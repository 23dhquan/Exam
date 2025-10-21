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
                                         .Select(q => new
                                         {
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
