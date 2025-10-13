namespace Exam.Forms
{
    partial class ExamPopupForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(30, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 23);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(30, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(30, 170);
            this.numDuration.Maximum = 300;
            this.numDuration.Minimum = 1;
            this.numDuration.Value = 60;
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.Location = new System.Drawing.Point(30, 210);
            this.cbClass.Size = new System.Drawing.Size(300, 23);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 260);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ExamPopupForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.btnSave);
            this.Name = "ExamPopupForm";
            this.Text = "Exam Form";

            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
