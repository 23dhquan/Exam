namespace Exam
{
    partial class StudentMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblClasses;
        private ListBox lstClasses;
        private Button btnJoinClass;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblClasses = new Label();
            this.lstClasses = new ListBox();
            this.btnJoinClass = new Button();
            this.btnLogout = new Button();

            // lblClasses
            this.lblClasses.Text = "Your Classes:";
            this.lblClasses.Location = new System.Drawing.Point(20, 20);
            this.lblClasses.AutoSize = true;

            // lstClasses
            this.lstClasses.Location = new System.Drawing.Point(20, 50);
            this.lstClasses.Size = new System.Drawing.Size(300, 200);

            // btnJoinClass
            this.btnJoinClass.Text = "Join Class";
            this.btnJoinClass.Location = new System.Drawing.Point(340, 50);
            this.btnJoinClass.Click += new System.EventHandler(this.btnJoinClass_Click);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Location = new System.Drawing.Point(340, 100);
            this.btnLogout.Click += (s, e) => { this.Close(); Application.Restart(); };

            // Form
            this.ClientSize = new System.Drawing.Size(480, 300);
            this.Controls.Add(lblClasses);
            this.Controls.Add(lstClasses);
            this.Controls.Add(btnJoinClass);
            this.Controls.Add(btnLogout);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Student Dashboard";
        }
    }
}
