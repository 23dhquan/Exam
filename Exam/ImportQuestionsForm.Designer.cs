namespace Exam
{
    partial class ImportQuestionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbExam;
        private Button btnBrowse;
        private Button btnImport;
        private Label lblExam;
        private Label lblFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbExam = new ComboBox();
            this.btnBrowse = new Button();
            this.btnImport = new Button();
            this.lblExam = new Label();
            this.lblFile = new Label();

            // lblExam
            this.lblExam.Text = "Select Exam:";
            this.lblExam.Location = new System.Drawing.Point(20, 20);
            this.lblExam.AutoSize = true;

            // cbExam
            this.cbExam.Location = new System.Drawing.Point(120, 20);
            this.cbExam.Size = new System.Drawing.Size(250, 25);

            // lblFile
            this.lblFile.Text = "No file selected";
            this.lblFile.Location = new System.Drawing.Point(20, 60);
            this.lblFile.AutoSize = true;

            // btnBrowse
            this.btnBrowse.Text = "Browse Excel";
            this.btnBrowse.Location = new System.Drawing.Point(20, 90);
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // btnImport
            this.btnImport.Text = "Import";
            this.btnImport.Location = new System.Drawing.Point(150, 90);
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.lblExam);
            this.Controls.Add(this.cbExam);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnImport);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Import Questions";
        }
    }
}
