/*
 * 由SharpDevelop创建。
 * 用户： sanhuo
 * 日期: 2016/1/5
 * 时间: 14:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Microsoft.Win32;

namespace MouseWheel
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		//定义操作目录
		string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Sanhuo\\MouseWheel";
		string WinFilePath;
		string OSXFilePath;
		string FaceFlag;
		string WinString;
		string OSXString;


		void MainFormLoad(object sender, EventArgs e)
		{
			CheckStats();
			SetConfigReg();

		}
		//备份注册表项
		void SetBakReg()
		{
			string BakFilePath = AppDataPath + "\\BackUp.reg";

			try {

				if (!Directory.Exists(AppDataPath)) {
					Directory.CreateDirectory(AppDataPath);
				}
				if (!File.Exists(BakFilePath)) {
					MessageBox.Show("后悔药将会藏在这里：\r\n" + BakFilePath, "准备召唤注册表程序");
					Process.Start("regedit", string.Format(" /E {0} {1} ", BakFilePath, "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Enum\\HID"));
				}


			} catch (Exception ee) {
				MessageBox.Show(ee.Message);
			}
		}
		//检查当前鼠标滚轮方向
		void CheckStats()
		{
			try {

				showlabel.Text = "";
				RegistryKey MouseKey;
				int count = 1;
				//检索子项
				MouseKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\HID", false);
				//检索所有子项HID下项目
				foreach (string TreeA in MouseKey.GetSubKeyNames()) 
				{

					RegistryKey TreeAkey = MouseKey.OpenSubKey(TreeA, false);
					foreach (string TreeB in TreeAkey.GetSubKeyNames()) 
					{
						//打开TreeAkey的子项
						RegistryKey TreeBkey = TreeAkey.OpenSubKey(TreeB, false);
						//检索Service=mouhid
						if (TreeBkey.GetValue("Service", "").Equals("mouhid"))
						{
							//打开TreeBkey的子项Device Parameters
							RegistryKey TreeCkey = TreeAkey.OpenSubKey(TreeB + "\\Device Parameters", false);
							if (TreeCkey.GetValue("FlipFlopWheel", RegistryValueKind.DWord) != null)
							{
								//读取FlipFlopWheel的值
								Int32 TreeC = (Int32)TreeCkey.GetValue("FlipFlopWheel", RegistryValueKind.DWord);

								CheckFlage(TreeC);

								showlabel.Text += (FaceFlag + "  " + count + "\r\n");

								count += 1;
							}
						}

					}
				}
			} catch (Exception msg) 
			{
				MessageBox.Show(msg.Message);
			}
		}
		void SetConfigReg()
		{
			try {

				showlabel.Text = "";
				WinFilePath = AppDataPath + "\\WinStyle.reg";
				OSXFilePath = AppDataPath + "\\OSXStyle.reg";
				if (!Directory.Exists(AppDataPath)) {
					Directory.CreateDirectory(AppDataPath);
				}
				if (File.Exists(WinFilePath)) {
					File.Delete(WinFilePath);
				}
				if (File.Exists(OSXFilePath)) {
					File.Delete(OSXFilePath);
				}
//

				RegistryKey MouseKey;
				string HeadString;
				int count = 1;
				//检索子项
				MouseKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\HID", false);
				//检索所有子项HID下项目
				foreach (string TreeA in MouseKey.GetSubKeyNames()) {

					RegistryKey TreeAkey = MouseKey.OpenSubKey(TreeA, false);
					foreach (string TreeB in TreeAkey.GetSubKeyNames()) {


						//打开TreeAkey的子项
						RegistryKey TreeBkey = TreeAkey.OpenSubKey(TreeB, false);
						//检索Service=mouhid
						if (TreeBkey.GetValue("Service", "").Equals("mouhid")) {
							//打开TreeBkey的子项Device Parameters
							RegistryKey TreeCkey = TreeAkey.OpenSubKey(TreeB + "\\Device Parameters", false);
							if (TreeCkey.GetValue("FlipFlopWheel", RegistryValueKind.DWord) != null) {
								//读取FlipFlopWheel的值
								Int32 TreeC = (Int32)TreeCkey.GetValue("FlipFlopWheel", RegistryValueKind.DWord);

								CheckFlage(TreeC);
//				                logtext.AppendText("USB名称  " + TreeC + "\r\n");

								String Path = "\\" + TreeA + "\\" + TreeB;
								String Name = (string)TreeBkey.GetValue("DeviceDesc", "");

//				                logtext.AppendText(WinFilePath+"\r\n");
//				               logtext.AppendText(OSXFilePath+"\r\n");

								showlabel.Text += ("M" + count + ": " + FaceFlag + "\r\n\r\n");

								if (count == 1) {
									HeadString = "Windows Registry Editor Version 5.00\r\n";
									WriteReg(WinFilePath, HeadString);
									WriteReg(OSXFilePath, HeadString);
								}

								WinString = "[" + MouseKey + Path + "\\Device Parameters]" + "\r\n" + "\"FlipFlopWheel\"=dword:00000000\r\n";

//				                logtext.AppendText(WriteString);
								WriteReg(WinFilePath, WinString);

								OSXString = "[" + MouseKey + Path + "\\Device Parameters]" + "\r\n" + "\"FlipFlopWheel\"=dword:00000001\r\n";
								WriteReg(OSXFilePath, OSXString);
								count += 1;

							}
						}

					}
				}
			} catch (Exception msg)
			{
				MessageBox.Show(msg.Message);
			}

		}
		void CheckFlage(int CheckMouse)
		{

			if (CheckMouse == 1) {
				osxbtn.Checked = true;

			}
			if (CheckMouse == 0) {
				winbtn.Checked = true;

			}
		}
		void WriteReg(string path, string WLstring)
		{
			try {
				FileStream fs = new FileStream(path, FileMode.Append);
				StreamWriter sw = new StreamWriter(fs);
				//开始写入
				sw.WriteLine(WLstring);
				//清空缓冲区
				sw.Flush();
				//关闭流
				sw.Close();
				fs.Close();
			} catch (Exception fileex) {
				MessageBox.Show(fileex.Message);
			}
		}
		void DoIt(string doFilePath)
		{
			try {
				Process.Start("regedit", string.Format(" /s {0} ", doFilePath));
			} catch (Exception doexc) {
				MessageBox.Show(doexc.Message);
			}
		}
		void OsxbtnCheckedChanged(object sender, EventArgs e)
		{
			FaceFlag = "O_O";
		}
		void WinbtnCheckedChanged(object sender, EventArgs e)
		{
			FaceFlag = "W_W";
		}
		void DoitbtnClick(object sender, EventArgs e)
		{
			try {

				SetBakReg();
				if (winbtn.Checked) {
					DoIt(WinFilePath);
				}
				if (osxbtn.Checked) {
					DoIt(OSXFilePath);
				}
				MessageBox.Show("成功啦，继续重启电脑生效的。。\r\n或者，USB鼠标可以重新拔插。。。");
				Application.Exit();
			} catch (Exception doee) {
				MessageBox.Show(doee.Message);
			}
		}
		void AboutbtnClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://sanhuo.info");
		}
	}
}
