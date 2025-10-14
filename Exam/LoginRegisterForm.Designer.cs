using Guna.UI2.WinForms;

namespace Exam
{
    partial class LoginRegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblTitle;
        private Guna2TextBox txtName, txtPassword;
        private Guna2Button btnLogin, btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Guna2HtmlLabel();
            this.txtName = new Guna2TextBox();
            this.txtPassword = new Guna2TextBox();
            this.btnLogin = new Guna2Button();
            this.btnRegister = new Guna2Button();

            // lblTitle
            this.lblTitle.Text = "🔐 Login / Register";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new System.Drawing.Size(600, 60);
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(315, 80);

            // txtName
            this.txtName.PlaceholderText = "Enter username";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.BorderRadius = 10;
            this.txtName.Size = new System.Drawing.Size(400, 45);
            this.txtName.Location = new System.Drawing.Point(415, 200);

            // txtPassword
            this.txtPassword.PlaceholderText = "Enter password";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(400, 45);
            this.txtPassword.Location = new System.Drawing.Point(415, 270);

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Size = new System.Drawing.Size(180, 50);
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLogin.Location = new System.Drawing.Point(415, 360);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Text = "Register";
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Size = new System.Drawing.Size(180, 50);
            this.btnRegister.BorderRadius = 10;
            this.btnRegister.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRegister.Location = new System.Drawing.Point(635, 360);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(1230, 720);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login / Register ";
            this.BackColor = System.Drawing.Color.White;
        }
    }
}
