using System;
using System.Linq;
using System.Windows.Forms;
using Exam.Models;

namespace Exam
{
    public partial class ClassPopupForm : Form
    {
        private Class? _class;
        private ExamSystemContext _db = new ExamSystemContext();
        private User _teacher; // lớp thuộc giảng viên nào

        public ClassPopupForm(User teacher, Class? cls = null)
        {
            _teacher = teacher;
            _class = cls;
            InitializeComponent();

            if (_class != null)
            {
                txtName.Text = _class.Name;
                txtCode.Text = _class.Code;
                txtDescription.Text = _class.Description;
                txtCode.Enabled = false; // không cho sửa code khi edit
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string code = txtCode.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Name and Code are required!");
                return;
            }

            if (_class == null)
            {
                if (_db.Classes.Any(c => c.Code == code))
                {
                    MessageBox.Show("Class code already exists!");
                    return;
                }

                var newClass = new Class
                {
                    Name = name,
                    Code = code,
                    Description = description,
                    TeacherId = _teacher.Id
                };

                _db.Classes.Add(newClass);
            }
            else
            {
                _class.Name = name;
                _class.Description = description;
                _db.Classes.Update(_class);
            }

            _db.SaveChanges();
            MessageBox.Show("Saved successfully!");
            this.Close();
        }
    }
}
