using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class UserManagementForm : Form
    {
        private ExamSystemContext _db = new ExamSystemContext();

        public UserManagementForm()
        {
            InitializeComponent();
            LoadClassFilter();
            LoadUsers();
        }

        private void LoadClassFilter()
        {
            cmbClassFilter.Items.Clear();
            cmbClassFilter.Items.Add("All Classes");
            var classes = _db.Classes.ToList();
            foreach (var c in classes) cmbClassFilter.Items.Add(c.Name);
            cmbClassFilter.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            var query = _db.Users.AsQueryable();

            // Filter theo class
            if (cmbClassFilter.SelectedIndex > 0)
            {
                string className = cmbClassFilter.SelectedItem.ToString();
                var classId = _db.Classes.FirstOrDefault(c => c.Name == className)?.Id;
                if (classId != null)
                {
                    var studentIds = _db.ClassStudents.Where(cs => cs.ClassId == classId).Select(cs => cs.StudentId);
                    query = query.Where(u => studentIds.Contains(u.Id));
                }
            }

            // Tìm kiếm
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(u => u.Name.Contains(keyword) || u.Email.Contains(keyword));

            var list = query.Select(u => new { u.Id, u.Name, u.Email, u.Role }).ToList();
            dgvUsers.DataSource = list;
            lblTotal.Text = $"Total: {list.Count}";
        }

        private void BtnSearch_Click(object sender, EventArgs e) => LoadUsers();
        private void CmbClassFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadUsers();
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e) => LoadUsers();
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new UserPopupForm();
            if (popup.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
            var user = _db.Users.Find(id);
            if (user == null) return;

            var popup = new UserPopupForm(user);
            if (popup.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
            var user = _db.Users.Find(id);
            if (user == null) return;

            if (MessageBox.Show($"Delete {user.Name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
                LoadUsers();
            }
        }
    }
}
