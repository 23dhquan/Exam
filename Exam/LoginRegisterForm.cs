using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class LoginRegisterForm : Form
    {
        private ExamSystemContext _db = new ExamSystemContext();

        public LoginRegisterForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            var user = _db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            this.Hide();

            switch (user.Role)
            {
                case "student":
                    new StudentMainForm(user).ShowDialog();
                    break;
                case "teacher":
                    new TeacherMainForm(user).ShowDialog();
                    break;
                case "admin":
                    new AdminMainForm(user).ShowDialog();
                    break;
            }

            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (_db.Users.Any(u => u.Name == username))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            var student = new User
            {
                Name = username,
                Password = password,
                Role = "student" // mặc định đăng ký là student
            };

            _db.Users.Add(student);
            _db.SaveChanges();

            MessageBox.Show("Registered successfully! Now login.");
        }

    }
}
