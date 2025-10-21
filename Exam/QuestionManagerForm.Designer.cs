using Guna.UI2.WinForms;

namespace Exam
{
    partial class QuestionManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblTitle;
        private Guna2DataGridView dgvQuestions;
        private Guna2Button btnImportExcel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Guna2HtmlLabel();
            this.dgvQuestions = new Guna2DataGridView();
       
            this.btnImportExcel = new Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();

            // ======= Label Title =======
            this.lblTitle.Text = "📚 Question Manager";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new System.Drawing.Size(800, 60);
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(200, 20);

            // ======= DataGridView =======
            this.dgvQuestions.Location = new System.Drawing.Point(50, 100);
            this.dgvQuestions.Size = new System.Drawing.Size(800, 500);
            this.dgvQuestions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuestions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvQuestions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQuestions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvQuestions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuestions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvQuestions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQuestions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvQuestions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.MultiSelect = false;
            this.dgvQuestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ======= Button Styles =======
            int btnWidth = 160;
            int btnHeight = 50;
            int btnX = 900;
            int btnYStart = 150;
            int btnSpacing = 70;

           
            // Edit
           

           
            // Import Excel
            this.btnImportExcel.Text = "📥 Import Excel";
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnImportExcel.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnImportExcel.BorderRadius = 10;
            this.btnImportExcel.Location = new System.Drawing.Point(btnX, btnYStart + btnSpacing * 3);
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // ======= Form =======
            this.ClientSize = new System.Drawing.Size(1230, 720);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question Manager (Guna UI2)";

            // ======= Add Controls =======
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvQuestions);
  
            this.Controls.Add(this.btnImportExcel);

            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
