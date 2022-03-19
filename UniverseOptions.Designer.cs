
namespace StevenAlexander_GOLProject
{
    partial class UniverseOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.YBox = new System.Windows.Forms.NumericUpDown();
            this.XBox = new System.Windows.Forms.NumericUpDown();
            this.Option1Label = new System.Windows.Forms.Label();
            this.UniverseX = new System.Windows.Forms.Label();
            this.UniverseY = new System.Windows.Forms.Label();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.Close_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Timing = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timing)).BeginInit();
            this.SuspendLayout();
            // 
            // YBox
            // 
            this.YBox.Location = new System.Drawing.Point(104, 33);
            this.YBox.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.YBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(40, 20);
            this.YBox.TabIndex = 1;
            this.YBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // XBox
            // 
            this.XBox.Location = new System.Drawing.Point(38, 33);
            this.XBox.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.XBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(40, 20);
            this.XBox.TabIndex = 0;
            this.XBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Option1Label
            // 
            this.Option1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Option1Label.Location = new System.Drawing.Point(12, 9);
            this.Option1Label.Name = "Option1Label";
            this.Option1Label.Size = new System.Drawing.Size(143, 50);
            this.Option1Label.TabIndex = 2;
            this.Option1Label.Text = "Change Universe Size";
            // 
            // UniverseX
            // 
            this.UniverseX.AutoSize = true;
            this.UniverseX.Location = new System.Drawing.Point(18, 35);
            this.UniverseX.Name = "UniverseX";
            this.UniverseX.Size = new System.Drawing.Size(14, 13);
            this.UniverseX.TabIndex = 0;
            this.UniverseX.Text = "X";
            // 
            // UniverseY
            // 
            this.UniverseY.AutoSize = true;
            this.UniverseY.Location = new System.Drawing.Point(84, 35);
            this.UniverseY.Name = "UniverseY";
            this.UniverseY.Size = new System.Drawing.Size(14, 13);
            this.UniverseY.TabIndex = 4;
            this.UniverseY.Text = "Y";
            // 
            // Ok_Button
            // 
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Location = new System.Drawing.Point(143, 71);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(75, 23);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "OK";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close_Button.Location = new System.Drawing.Point(224, 71);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(75, 23);
            this.Close_Button.TabIndex = 6;
            this.Close_Button.Text = "Close";
            this.Close_Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(161, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "Change Universe Timing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "50 - 2000 ms";
            // 
            // Timing
            // 
            this.Timing.Location = new System.Drawing.Point(235, 32);
            this.Timing.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Timing.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Timing.Name = "Timing";
            this.Timing.Size = new System.Drawing.Size(57, 20);
            this.Timing.TabIndex = 9;
            this.Timing.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // UniverseOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 103);
            this.Controls.Add(this.Timing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.UniverseY);
            this.Controls.Add(this.UniverseX);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.XBox);
            this.Controls.Add(this.Option1Label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UniverseOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Universe Options";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown YBox;
        private System.Windows.Forms.NumericUpDown XBox;
        private System.Windows.Forms.Label Option1Label;
        private System.Windows.Forms.Label UniverseX;
        private System.Windows.Forms.Label UniverseY;
        private System.Windows.Forms.Button Ok_Button;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Timing;
    }
}