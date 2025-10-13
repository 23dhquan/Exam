namespace Exam
{
    partial class LoginRegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName, lblPassword;
        private TextBox txtName, txtPassword;
        private Button btnLogin, btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();

            // lblName
            this.lblName.Text = "Username:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.AutoSize = true;

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Width = 200;

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(20, 60);
            this.lblPassword.AutoSize = true;

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 57);
            this.txtPassword.Width = 200;
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(120, 100);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new System.Drawing.Point(220, 100);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(360, 150);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Login / Register";
        }
    }
}
