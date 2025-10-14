using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class AdminMainForm : Form
    {
        private User _admin;
        private ExamSystemContext _db = new ExamSystemContext();
        private string currentView = "";

        public AdminMainForm(User admin)
        {
            _admin = admin;
            InitializeComponent();
            ShowCrudPanel("Users");
        }

        private void ShowCrudPanel(string view)
        {
            currentView = view;
            crudUsersPanel.Visible = (view == "Users");
            crudClassesPanel.Visible = (view == "Classes");
            crudExamsPanel.Visible = (view == "Exams");

            if (view == "Users") LoadUsers();
            else if (view == "Classes") LoadClasses();
            else if (view == "Exams") LoadExams();
        }

        private void LoadUsers()
        {
            dgvMain.DataSource = _db.Users
                .Select(u => new { u.Id, u.Name, u.Email, u.Role, u.CreatedAt })
                .ToList();
        }

        private void LoadClasses()
        {
            dgvMain.DataSource = _db.Classes
                .Select(c => new { c.Id, c.Name, c.Code, Teacher = c.Teacher.Name, c.CreatedAt })
                .ToList();
            cmbClassTeacher.Items.Clear();
            cmbClassTeacher.Items.AddRange(_db.Users.Where(u => u.Role == "teacher").Select(u => u.Name).ToArray());
        }

        private void LoadExams()
        {
            dgvMain.DataSource = _db.Exams
                .Select(e => new { e.Id, e.Title, e.Description, Teacher = e.Teacher.Name, Class = e.Class.Name, e.StartTime, e.EndTime, e.Duration })
                .ToList();
            cmbExamTeacher.Items.Clear();
            cmbExamTeacher.Items.AddRange(_db.Users.Where(u => u.Role == "teacher").Select(u => u.Name).ToArray());

            cmbExamClass.Items.Clear();
            cmbExamClass.Items.AddRange(_db.Classes.Select(c => c.Name).ToArray());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentView == "Users")
            {
                int? id = dgvMain.CurrentRow != null ? (int?)dgvMain.CurrentRow.Cells["Id"].Value : null;
                User user = id.HasValue ? _db.Users.Find(id.Value) : new User();

                user.Name = txtUserName.Text;
                user.Email = txtUserEmail.Text;
                user.Role = cmbUserRole.SelectedItem?.ToString();

                if (!id.HasValue) _db.Users.Add(user);
                _db.SaveChanges();
                LoadUsers();
            }
            else if (currentView == "Classes")
            {
                int? id = dgvMain.CurrentRow != null ? (int?)dgvMain.CurrentRow.Cells["Id"].Value : null;
                Class cls = id.HasValue ? _db.Classes.Find(id.Value) : new Class();

                cls.Name = txtClassName.Text;
                cls.Code = txtClassCode.Text;

                string selectedTeacher = cmbClassTeacher.SelectedItem != null ? cmbClassTeacher.SelectedItem.ToString() : null;
                var teacher = _db.Users.FirstOrDefault(u => u.Name == selectedTeacher && u.Role == "teacher");
                if (teacher != null) cls.TeacherId = teacher.Id;

                if (!id.HasValue) _db.Classes.Add(cls);
                _db.SaveChanges();
                LoadClasses();
            }
            else if (currentView == "Exams")
            {
                int? id = dgvMain.CurrentRow != null ? (int?)dgvMain.CurrentRow.Cells["Id"].Value : null;
                Exam.Models.Exam exam = id.HasValue ? _db.Exams.Find(id.Value) : new Exam.Models.Exam();

                exam.Title = txtExamTitle.Text;
                exam.Description = txtExamDescription.Text;

                string selectedTeacher = cmbExamTeacher.SelectedItem != null ? cmbExamTeacher.SelectedItem.ToString() : null;
                var teacher = _db.Users.FirstOrDefault(u => u.Name == selectedTeacher && u.Role == "teacher");
                if (teacher != null) exam.TeacherId = teacher.Id;

                string selectedClass = cmbExamClass.SelectedItem != null ? cmbExamClass.SelectedItem.ToString() : null;
                var cls = _db.Classes.FirstOrDefault(c => c.Name == selectedClass && c.TeacherId == teacher.Id);
                if (cls != null) exam.ClassId = cls.Id;

                exam.StartTime = dtpExamStart.Value;
                exam.EndTime = dtpExamEnd.Value;
                exam.Duration = (int)nudExamDuration.Value;

                if (!id.HasValue) _db.Exams.Add(exam);
                _db.SaveChanges();
                LoadExams();
            }
            ClearCrudInputs();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null) return;
            int id = (int)dgvMain.CurrentRow.Cells["Id"].Value;

            if (currentView == "Users")
            {
                var user = _db.Users.Find(id);
                if (user != null) _db.Users.Remove(user);
            }
            else if (currentView == "Classes")
            {
                var cls = _db.Classes.Find(id);
                if (cls != null) _db.Classes.Remove(cls);
            }
            else if (currentView == "Exams")
            {
                var exam = _db.Exams.Find(id);
                if (exam != null) _db.Exams.Remove(exam);
            }

            _db.SaveChanges();
            if (currentView == "Users") LoadUsers();
            else if (currentView == "Classes") LoadClasses();
            else if (currentView == "Exams") LoadExams();

            ClearCrudInputs();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearCrudInputs();
        }

        private void ClearCrudInputs()
        {
            txtUserName.Text = txtUserEmail.Text = "";
            cmbUserRole.SelectedIndex = -1;

            txtClassName.Text = txtClassCode.Text = "";
            cmbClassTeacher.SelectedIndex = -1;

            txtExamTitle.Text = txtExamDescription.Text = "";
            cmbExamTeacher.SelectedIndex = -1;
            cmbExamClass.SelectedIndex = -1;
            dtpExamStart.Value = DateTime.Now;
            dtpExamEnd.Value = DateTime.Now;
            nudExamDuration.Value = 30;
        }

        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow == null) return;

            if (currentView == "Users")
            {
                txtUserName.Text = dgvMain.CurrentRow.Cells["Name"].Value?.ToString();
                txtUserEmail.Text = dgvMain.CurrentRow.Cells["Email"].Value?.ToString();
                cmbUserRole.SelectedItem = dgvMain.CurrentRow.Cells["Role"].Value?.ToString();
            }
            else if (currentView == "Classes")
            {
                txtClassName.Text = dgvMain.CurrentRow.Cells["Name"].Value?.ToString();
                txtClassCode.Text = dgvMain.CurrentRow.Cells["Code"].Value?.ToString();
                cmbClassTeacher.SelectedItem = dgvMain.CurrentRow.Cells["Teacher"].Value?.ToString();
            }
            else if (currentView == "Exams")
            {
                txtExamTitle.Text = dgvMain.CurrentRow.Cells["Title"].Value?.ToString();
                txtExamDescription.Text = dgvMain.CurrentRow.Cells["Description"].Value?.ToString();
                cmbExamTeacher.SelectedItem = dgvMain.CurrentRow.Cells["Teacher"].Value?.ToString();
                cmbExamClass.SelectedItem = dgvMain.CurrentRow.Cells["Class"].Value?.ToString();
                nudExamDuration.Value = dgvMain.CurrentRow.Cells["Duration"].Value != null ? Convert.ToDecimal(dgvMain.CurrentRow.Cells["Duration"].Value) : 30;
            }
        }
    }
}
