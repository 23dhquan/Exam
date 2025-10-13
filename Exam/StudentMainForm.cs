using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class StudentMainForm : Form
    {
        private User _student;
        private ExamSystemContext _db = new ExamSystemContext();

        public StudentMainForm(User student)
        {
            _student = student;
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            lstClasses.Items.Clear();
            var classes = _db.ClassStudents
                             .Where(cs => cs.StudentId == _student.Id)
                             .Select(cs => cs.Class)
                             .ToList();

            foreach (var c in classes)
            {
                lstClasses.Items.Add($"{c.Name} ({c.Code})");
            }
        }

        private void btnJoinClass_Click(object sender, EventArgs e)
        {
            string code = Microsoft.VisualBasic.Interaction.InputBox("Enter class code to join:", "Join Class");
            if (string.IsNullOrEmpty(code)) return;

            var cls = _db.Classes.FirstOrDefault(c => c.Code == code);
            if (cls == null)
            {
                MessageBox.Show("Class not found.");
                return;
            }

            if (_db.ClassStudents.Any(cs => cs.ClassId == cls.Id && cs.StudentId == _student.Id))
            {
                MessageBox.Show("You already joined this class.");
                return;
            }

            _db.ClassStudents.Add(new ClassStudent { ClassId = cls.Id, StudentId = _student.Id });
            _db.SaveChanges();
            MessageBox.Show("Joined class successfully!");
            LoadClasses();
        }
    }
}
