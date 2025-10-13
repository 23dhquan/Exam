using System;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class UserPopupForm : Form
    {
        private ExamSystemContext _db = new ExamSystemContext();
        private User _user;

        public UserPopupForm(User user = null)
        {
            _user = user;
            InitializeComponent();

            cmbRole.Items.AddRange(new string[] { "teacher", "student", "admin" });
            cmbRole.SelectedIndex = 0;

            if (_user != null)
            {
                txtName.Text = _user.Name;
                txtEmail.Text = _user.Email;
                cmbRole.SelectedItem = _user.Role;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user == null)
            {
                _user = new User();
                _db.Users.Add(_user);
            }

            _user.Name = txtName.Text.Trim();
            _user.Email = txtEmail.Text.Trim();
            _user.Role = cmbRole.SelectedItem.ToString()!;
            _user.Password = "123456"; // default password

            _db.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
