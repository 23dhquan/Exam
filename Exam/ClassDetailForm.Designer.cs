using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    partial class ClassDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblTitle;
        private FlowLayoutPanel flowExams;
        private Guna2Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Guna2HtmlLabel();
            flowExams = new FlowLayoutPanel();
            btnBack = new Guna2Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(300, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(630, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Exams for Class";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // flowExams
            // 
            flowExams.AutoScroll = true;
            flowExams.Dock = DockStyle.Bottom;
            flowExams.Location = new Point(0, 100);
            flowExams.Name = "flowExams";
            flowExams.Size = new Size(1230, 620);
            flowExams.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges3;
            btnBack.FillColor = Color.Gray;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(20, 20);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnBack.Size = new Size(120, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // ClassDetailForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1230, 720);
            Controls.Add(btnBack);
            Controls.Add(lblTitle);
            Controls.Add(flowExams);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ClassDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Class Details";
            ResumeLayout(false);
        }
    }
}
