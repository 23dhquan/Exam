namespace Exam
{
    partial class ClassPopupForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName, lblCode, lblDescription;
        private TextBox txtName, txtCode, txtDescription;
        private Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblCode = new Label();
            this.txtCode = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // lblName
            this.lblName.Text = "Class Name:";
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.AutoSize = true;

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.Width = 250;

            // lblCode
            this.lblCode.Text = "Class Code:";
            this.lblCode.Location = new System.Drawing.Point(12, 50);
            this.lblCode.AutoSize = true;

            // txtCode
            this.txtCode.Location = new System.Drawing.Point(120, 47);
            this.txtCode.Width = 150;

            // lblDescription
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(12, 85);
            this.lblDescription.AutoSize = true;

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 82);
            this.txtDescription.Width = 250;
            this.txtDescription.Height = 60;
            this.txtDescription.Multiline = true;

            // btnSave
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(120, 160);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(220, 160);
            this.btnCancel.Click += (s, e) => this.Close();

            // Form
            this.ClientSize = new System.Drawing.Size(400, 210);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblCode);
            this.Controls.Add(txtCode);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
