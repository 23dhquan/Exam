namespace Exam
{
    partial class TakeExamForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlQuestions;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimer;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlQuestions = new Guna.UI2.WinForms.Guna2Panel();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            lblTimer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // pnlQuestions
            // 
            pnlQuestions.AutoScroll = true;
            pnlQuestions.Dock = DockStyle.Top;
            pnlQuestions.Location = new Point(0, 0);
            pnlQuestions.Name = "pnlQuestions";
            pnlQuestions.Size = new Size(1230, 600);
            pnlQuestions.TabIndex = 0;
            // 
            // btnSubmit
            // 
            btnSubmit.Dock = DockStyle.Bottom;
            btnSubmit.Text = "Nộp bài";
            btnSubmit.FillColor = System.Drawing.Color.Crimson;
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSubmit.Height = 60;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblTimer
            // 
            lblTimer.Dock = DockStyle.Bottom;
            lblTimer.BackColor = System.Drawing.Color.Transparent;
            lblTimer.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTimer.ForeColor = System.Drawing.Color.DarkBlue;
            lblTimer.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            lblTimer.Height = 40;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // TakeExamForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 720);
            Controls.Add(pnlQuestions);
            Controls.Add(lblTimer);
            Controls.Add(btnSubmit);
            Name = "TakeExamForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Làm bài thi";
            ResumeLayout(false);
        }
    }
}
