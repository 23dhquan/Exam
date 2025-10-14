using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Exam
{
    partial class StudentMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowClasses;
        private Guna2Button btnJoinClass;
        private Guna2Panel mainPanel;
        private Guna2HtmlLabel lblHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Guna2Panel();
            flowClasses = new FlowLayoutPanel();
            lblHeader = new Guna2HtmlLabel();
            btnJoinClass = new Guna2Button();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(flowClasses);
            mainPanel.Controls.Add(lblHeader);
            mainPanel.Controls.Add(btnJoinClass);
            mainPanel.CustomizableEdges = customizableEdges3;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.FillColor = Color.WhiteSmoke;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mainPanel.ShadowDecoration.Enabled = true;
            mainPanel.Size = new Size(1230, 720);
            mainPanel.TabIndex = 0;
            // 
            // flowClasses
            // 
            flowClasses.AutoScroll = true;
            flowClasses.BackColor = Color.White;
            flowClasses.Dock = DockStyle.Fill;
            flowClasses.Location = new Point(20, 80);
            flowClasses.Name = "flowClasses";
            flowClasses.Padding = new Padding(20);
            flowClasses.Size = new Size(1190, 560);
            flowClasses.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = false;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1190, 60);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Your Classes";
            lblHeader.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnJoinClass
            // 
            btnJoinClass.BorderRadius = 10;
            btnJoinClass.CustomizableEdges = customizableEdges1;
            btnJoinClass.Dock = DockStyle.Bottom;
            btnJoinClass.FillColor = Color.SeaGreen;
            btnJoinClass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnJoinClass.ForeColor = Color.White;
            btnJoinClass.Location = new Point(20, 640);
            btnJoinClass.Name = "btnJoinClass";
            btnJoinClass.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnJoinClass.Size = new Size(1190, 60);
            btnJoinClass.TabIndex = 2;
            btnJoinClass.Text = "Join Class";
            btnJoinClass.Click += btnJoinClass_Click;
            // 
            // StudentMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 720);
            Controls.Add(mainPanel);
            Name = "StudentMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
