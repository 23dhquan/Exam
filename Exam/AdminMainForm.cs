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

        public AdminMainForm(User admin)
        {
            _admin = admin;
            InitializeComponent();
            LoadRoleFilter();
            LoadUsers();
        }

        private void LoadRoleFilter()
        {
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.Add("All Roles");
            cmbRoleFilter.Items.Add("student");
            cmbRoleFilter.Items.Add("teacher");
            cmbRoleFilter.Items.Add("admin");
            cmbRoleFilter.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            string? roleFilter = cmbRoleFilter.SelectedItem?.ToString();
            var users = _db.Users.AsQueryable();

            if (!string.IsNullOrEmpty(roleFilter) && roleFilter != "All Roles")
                users = users.Where(u => u.Role == roleFilter);

            dgvUsers.DataSource = users
                                  .Select(u => new { u.Id, u.Name, u.Email, u.Role, u.CreatedAt })
                                  .ToList();
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var popup = new UserPopupForm(); // popup form giống trước
            popup.ShowDialog();
            LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
            var user = _db.Users.Find(userId);
            if (user == null) return;

            var popup = new UserPopupForm(user);
            popup.ShowDialog();
            LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
            var user = _db.Users.Find(userId);
            if (user == null) return;

            if (MessageBox.Show("Are you sure to delete this user?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
                LoadUsers();
            }
        }
    }
}
