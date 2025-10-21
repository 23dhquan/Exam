using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class TeacherMainForm : Form
    {
        private User _teacher;
        private ExamSystemContext _db = new ExamSystemContext();
        private User _currentTeacher;

        public TeacherMainForm(User teacher)
        {
            _teacher = teacher;
            _currentTeacher = teacher;
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            dgvClasses.DataSource = _db.Classes
                .Where(c => c.TeacherId == _teacher.Id)
                .Select(c => new { c.Id, c.Name, c.Code, c.Description })
                .ToList();

            // Ẩn cột ID
            if (dgvClasses.Columns["Id"] != null)
                dgvClasses.Columns["Id"].Visible = false;
        }
        private void dgvClasses_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int classId = (int)dgvClasses.Rows[e.RowIndex].Cells["Id"].Value;
                var detailForm = new ClassDetailTeacherForm(classId);
                detailForm.ShowDialog();
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var popup = new ClassPopupForm(_currentTeacher); // thêm lớp mới
            popup.ShowDialog();
            LoadClasses();
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow == null) return;
            int classId = (int)dgvClasses.CurrentRow.Cells["Id"].Value;
            var cls = _db.Classes.Find(classId);
            if (cls == null) return;

            var popup = new ClassPopupForm(_currentTeacher, cls); // sửa lớp
            popup.ShowDialog();
            LoadClasses();
        }


        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow == null) return;
            int classId = (int)dgvClasses.CurrentRow.Cells["Id"].Value;
            var cls = _db.Classes.Find(classId);
            if (cls == null) return;

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _db.Classes.Remove(cls);
                _db.SaveChanges();
                LoadClasses();
            }
        }
    }
}
