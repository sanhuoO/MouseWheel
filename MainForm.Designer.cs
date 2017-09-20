/*
 * 由SharpDevelop创建。
 * 用户： lhfx
 * 日期: 2016/1/5
 * 时间: 14:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MouseWheel
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label showlabel;
		private System.Windows.Forms.Button doitbtn;
		private System.Windows.Forms.RadioButton winbtn;
		private System.Windows.Forms.RadioButton osxbtn;
		private System.Windows.Forms.Button aboutbtn;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.showlabel = new System.Windows.Forms.Label();
			this.doitbtn = new System.Windows.Forms.Button();
			this.winbtn = new System.Windows.Forms.RadioButton();
			this.osxbtn = new System.Windows.Forms.RadioButton();
			this.aboutbtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// showlabel
			// 
			this.showlabel.Location = new System.Drawing.Point(12, 21);
			this.showlabel.Name = "showlabel";
			this.showlabel.Size = new System.Drawing.Size(75, 119);
			this.showlabel.TabIndex = 0;
			// 
			// doitbtn
			// 
			this.doitbtn.Location = new System.Drawing.Point(222, 21);
			this.doitbtn.Name = "doitbtn";
			this.doitbtn.Size = new System.Drawing.Size(75, 50);
			this.doitbtn.TabIndex = 3;
			this.doitbtn.Text = "Do it";
			this.doitbtn.UseVisualStyleBackColor = true;
			this.doitbtn.Click += new System.EventHandler(this.DoitbtnClick);
			// 
			// winbtn
			// 
			this.winbtn.Location = new System.Drawing.Point(94, 21);
			this.winbtn.Name = "winbtn";
			this.winbtn.Size = new System.Drawing.Size(104, 50);
			this.winbtn.TabIndex = 4;
			this.winbtn.TabStop = true;
			this.winbtn.Text = "Win 滚动条式";
			this.winbtn.UseVisualStyleBackColor = true;
			this.winbtn.CheckedChanged += new System.EventHandler(this.WinbtnCheckedChanged);
			// 
			// osxbtn
			// 
			this.osxbtn.Location = new System.Drawing.Point(94, 90);
			this.osxbtn.Name = "osxbtn";
			this.osxbtn.Size = new System.Drawing.Size(104, 50);
			this.osxbtn.TabIndex = 4;
			this.osxbtn.TabStop = true;
			this.osxbtn.Text = "OSX 自然滚式";
			this.osxbtn.UseVisualStyleBackColor = true;
			this.osxbtn.CheckedChanged += new System.EventHandler(this.OsxbtnCheckedChanged);
			// 
			// aboutbtn
			// 
			this.aboutbtn.Location = new System.Drawing.Point(222, 90);
			this.aboutbtn.Name = "aboutbtn";
			this.aboutbtn.Size = new System.Drawing.Size(75, 50);
			this.aboutbtn.TabIndex = 5;
			this.aboutbtn.Text = "sanhuo";
			this.aboutbtn.UseVisualStyleBackColor = true;
			this.aboutbtn.Click += new System.EventHandler(this.AboutbtnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(325, 178);
			this.Controls.Add(this.aboutbtn);
			this.Controls.Add(this.osxbtn);
			this.Controls.Add(this.winbtn);
			this.Controls.Add(this.doitbtn);
			this.Controls.Add(this.showlabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "鼠标滚动向 V1.0.3";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);

		}
	}
}