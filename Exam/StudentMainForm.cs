using System;
using System.Drawing;
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
            flowClasses.Controls.Clear();
            var classes = _db.ClassStudents
                             .Where(cs => cs.StudentId == _student.Id)
                             .Select(cs => cs.Class)
                             .ToList();

            foreach (var c in classes)
            {
                Panel card = CreateClassCard(c);
                flowClasses.Controls.Add(card);
            }
        }

        private Panel CreateClassCard(Class cls)
        {
            Panel card = new Panel();
            card.Width = 280;   // mỗi card vừa với màn hình lớn
            card.Height = 150;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(15);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;
            card.Tag = cls;

            Label lblName = new Label();
            lblName.Text = cls.Name;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.Dock = DockStyle.Top;
            lblName.Height = 40;
            lblName.TextAlign = ContentAlignment.MiddleCenter;

            Label lblCode = new Label();
            lblCode.Text = $"Code: {cls.Code}";
            lblCode.Dock = DockStyle.Fill;
            lblCode.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblCode.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(lblCode);
            card.Controls.Add(lblName);

            // Double click mở ClassDetailForm
            card.DoubleClick += (s, e) =>
{
    ClassDetailForm detailForm = new ClassDetailForm(_student, cls);
    detailForm.ShowDialog();
};

// Nếu card có label hoặc hình ảnh bên trong, cũng cần gắn DoubleClick cho chúng:
foreach (Control ctrl in card.Controls)
{
    ctrl.DoubleClick += (s, e) =>
    {
        ClassDetailForm detailForm = new ClassDetailForm(_student, cls);
        detailForm.ShowDialog();
    };
}


            // Hover effect
            card.MouseEnter += (s, e) => card.BackColor = Color.AliceBlue;
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
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
