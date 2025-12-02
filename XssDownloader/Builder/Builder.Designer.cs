namespace Builder
{
    partial class Builder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            Github = new Button();
            Link = new TextBox();
            label1 = new Label();
            Path2 = new Label();
            Path = new TextBox();
            Build = new Button();
            SuspendLayout();
            // 
            // Github
            // 
            Github.BackColor = Color.Transparent;
            Github.Location = new Point(1, 1);
            Github.Name = "Github";
            Github.Size = new Size(75, 23);
            Github.TabIndex = 0;
            Github.Text = "Github";
            Github.UseVisualStyleBackColor = false;
            Github.Click += Github_Click;
            // 
            // Link
            // 
            Link.Location = new Point(73, 102);
            Link.Name = "Link";
            Link.Size = new Size(227, 23);
            Link.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 105);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Link";
            // 
            // Path2
            // 
            Path2.AutoSize = true;
            Path2.BackColor = Color.Transparent;
            Path2.ForeColor = Color.White;
            Path2.Location = new Point(22, 141);
            Path2.Name = "Path2";
            Path2.Size = new Size(31, 15);
            Path2.TabIndex = 3;
            Path2.Text = "Path";
            // 
            // Path
            // 
            Path.Location = new Point(73, 141);
            Path.Name = "Path";
            Path.Size = new Size(231, 23);
            Path.TabIndex = 4;
            // 
            // Build
            // 
            Build.BackColor = Color.Transparent;
            Build.Location = new Point(205, 317);
            Build.Name = "Build";
            Build.Size = new Size(75, 23);
            Build.TabIndex = 5;
            Build.Text = "Build";
            Build.UseVisualStyleBackColor = false;
            Build.Click += Build_Click;
            // 
            // Builder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(573, 432);
            Controls.Add(Build);
            Controls.Add(Path);
            Controls.Add(Path2);
            Controls.Add(label1);
            Controls.Add(Link);
            Controls.Add(Github);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Builder";
            Text = "XssDownloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Github;
        private TextBox Link;
        private Label label1;
        private Label Path2;
        private TextBox Path;
        private Button Build;
    }
}
