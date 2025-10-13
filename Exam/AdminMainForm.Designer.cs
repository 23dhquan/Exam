namespace Exam
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem usersMenuItem, classesMenuItem, examsMenuItem, logoutMenuItem;
        private DataGridView dgvUsers;
        private ComboBox cmbRoleFilter;
        private Button btnAddUser, btnEditUser, btnDeleteUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.usersMenuItem = new ToolStripMenuItem();
            this.classesMenuItem = new ToolStripMenuItem();
            this.examsMenuItem = new ToolStripMenuItem();
            this.logoutMenuItem = new ToolStripMenuItem();
            this.dgvUsers = new DataGridView();
            this.cmbRoleFilter = new ComboBox();
            this.btnAddUser = new Button();
            this.btnEditUser = new Button();
            this.btnDeleteUser = new Button();

            // MenuStrip
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { usersMenuItem, classesMenuItem, examsMenuItem, logoutMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);

            this.usersMenuItem.Text = "Users";
            this.classesMenuItem.Text = "Classes";
            this.examsMenuItem.Text = "Exams";
            this.logoutMenuItem.Text = "Logout";
            this.logoutMenuItem.Click += (s, e) => { this.Close(); Application.Restart(); };

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(20, 60);
            this.dgvUsers.Size = new System.Drawing.Size(500, 400);
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;

            // cmbRoleFilter
            this.cmbRoleFilter.Location = new System.Drawing.Point(540, 60);
            this.cmbRoleFilter.Width = 150;
            this.cmbRoleFilter.SelectedIndexChanged += new EventHandler(this.cmbRoleFilter_SelectedIndexChanged);

            // btnAddUser
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Location = new System.Drawing.Point(540, 100);
            this.btnAddUser.Click += new EventHandler(this.btnAddUser_Click);

            // btnEditUser
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.Location = new System.Drawing.Point(540, 140);
            this.btnEditUser.Click += new EventHandler(this.btnEditUser_Click);

            // btnDeleteUser
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Location = new System.Drawing.Point(540, 180);
            this.btnDeleteUser.Click += new EventHandler(this.btnDeleteUser_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(720, 500);
            this.Controls.Add(dgvUsers);
            this.Controls.Add(cmbRoleFilter);
            this.Controls.Add(btnAddUser);
            this.Controls.Add(btnEditUser);
            this.Controls.Add(btnDeleteUser);
            this.Controls.Add(menuStrip1);
            this.MainMenuStrip = menuStrip1;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
        }
    }
}
