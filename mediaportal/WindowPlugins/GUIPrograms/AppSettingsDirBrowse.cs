using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using ProgramsDatabase;
using Programs.Utils;

namespace WindowPlugins.GUIPrograms
{
	public class AppSettingsDirBrowse : WindowPlugins.GUIPrograms.AppSettings
	{
		private System.Windows.Forms.CheckBox chkbUseShellExecute;
		private System.Windows.Forms.CheckBox chkbUseQuotes;
		private System.Windows.Forms.Button btnStartup;
		private System.Windows.Forms.TextBox txtStartupDir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbWindowStyle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtArguments;
		private System.Windows.Forms.Label lblArg;
		private System.Windows.Forms.Label lblImageFile;
		private System.Windows.Forms.TextBox txtImageFile;
		private System.Windows.Forms.CheckBox chkbEnabled;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.Label lblImgDirectories;
		private System.Windows.Forms.TextBox txtExtensions;
		private System.Windows.Forms.TextBox txtImageDirs;
		private System.Windows.Forms.TextBox txtFiles;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonImagefile;
		private System.Windows.Forms.Button buttonLaunchingApp;
		private System.Windows.Forms.Button buttonFiledir;
		private System.Windows.Forms.Button buttonImageDirs;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components = null;

		public AppSettingsDirBrowse()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.chkbUseShellExecute = new System.Windows.Forms.CheckBox();
			this.chkbUseQuotes = new System.Windows.Forms.CheckBox();
			this.btnStartup = new System.Windows.Forms.Button();
			this.txtStartupDir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbWindowStyle = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.lblArg = new System.Windows.Forms.Label();
			this.lblImageFile = new System.Windows.Forms.Label();
			this.buttonImagefile = new System.Windows.Forms.Button();
			this.txtImageFile = new System.Windows.Forms.TextBox();
			this.chkbEnabled = new System.Windows.Forms.CheckBox();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblFilename = new System.Windows.Forms.Label();
			this.buttonLaunchingApp = new System.Windows.Forms.Button();
			this.lblImgDirectories = new System.Windows.Forms.Label();
			this.buttonFiledir = new System.Windows.Forms.Button();
			this.txtExtensions = new System.Windows.Forms.TextBox();
			this.txtImageDirs = new System.Windows.Forms.TextBox();
			this.txtFiles = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonImageDirs = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// chkbUseShellExecute
			// 
			this.chkbUseShellExecute.Location = new System.Drawing.Point(120, 118);
			this.chkbUseShellExecute.Name = "chkbUseShellExecute";
			this.chkbUseShellExecute.Size = new System.Drawing.Size(176, 24);
			this.chkbUseShellExecute.TabIndex = 61;
			this.chkbUseShellExecute.Text = "Startup using ShellExecute";
			// 
			// chkbUseQuotes
			// 
			this.chkbUseQuotes.Checked = true;
			this.chkbUseQuotes.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkbUseQuotes.Location = new System.Drawing.Point(120, 240);
			this.chkbUseQuotes.Name = "chkbUseQuotes";
			this.chkbUseQuotes.Size = new System.Drawing.Size(184, 24);
			this.chkbUseQuotes.TabIndex = 60;
			this.chkbUseQuotes.Text = "Quotes around Filenames";
			// 
			// btnStartup
			// 
			this.btnStartup.Location = new System.Drawing.Point(376, 216);
			this.btnStartup.Name = "btnStartup";
			this.btnStartup.Size = new System.Drawing.Size(20, 20);
			this.btnStartup.TabIndex = 59;
			this.btnStartup.Text = "...";
			this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
			// 
			// txtStartupDir
			// 
			this.txtStartupDir.Location = new System.Drawing.Point(120, 216);
			this.txtStartupDir.Name = "txtStartupDir";
			this.txtStartupDir.Size = new System.Drawing.Size(250, 20);
			this.txtStartupDir.TabIndex = 58;
			this.txtStartupDir.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 216);
			this.label5.Name = "label5";
			this.label5.TabIndex = 69;
			this.label5.Text = "Startup Directory:";
			// 
			// cbWindowStyle
			// 
			this.cbWindowStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWindowStyle.Items.AddRange(new object[] {
															   "Normal",
															   "Minimized",
															   "Maximized",
															   "Hidden"});
			this.cbWindowStyle.Location = new System.Drawing.Point(120, 192);
			this.cbWindowStyle.Name = "cbWindowStyle";
			this.cbWindowStyle.Size = new System.Drawing.Size(250, 21);
			this.cbWindowStyle.TabIndex = 57;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 192);
			this.label1.Name = "label1";
			this.label1.TabIndex = 68;
			this.label1.Text = "Window-Style:";
			// 
			// txtArguments
			// 
			this.txtArguments.Location = new System.Drawing.Point(120, 168);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(250, 20);
			this.txtArguments.TabIndex = 56;
			this.txtArguments.Text = "";
			// 
			// lblArg
			// 
			this.lblArg.Location = new System.Drawing.Point(0, 168);
			this.lblArg.Name = "lblArg";
			this.lblArg.TabIndex = 67;
			this.lblArg.Text = "Arguments:";
			// 
			// lblImageFile
			// 
			this.lblImageFile.Location = new System.Drawing.Point(0, 144);
			this.lblImageFile.Name = "lblImageFile";
			this.lblImageFile.Size = new System.Drawing.Size(80, 20);
			this.lblImageFile.TabIndex = 66;
			this.lblImageFile.Text = "Imagefile:";
			// 
			// buttonImagefile
			// 
			this.buttonImagefile.Location = new System.Drawing.Point(376, 144);
			this.buttonImagefile.Name = "buttonImagefile";
			this.buttonImagefile.Size = new System.Drawing.Size(20, 20);
			this.buttonImagefile.TabIndex = 55;
			this.buttonImagefile.Text = "...";
			this.buttonImagefile.Click += new System.EventHandler(this.buttonImagefile_Click);
			// 
			// txtImageFile
			// 
			this.txtImageFile.Location = new System.Drawing.Point(120, 144);
			this.txtImageFile.Name = "txtImageFile";
			this.txtImageFile.Size = new System.Drawing.Size(250, 20);
			this.txtImageFile.TabIndex = 54;
			this.txtImageFile.Text = "";
			// 
			// chkbEnabled
			// 
			this.chkbEnabled.Checked = true;
			this.chkbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkbEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkbEnabled.Location = new System.Drawing.Point(8, 40);
			this.chkbEnabled.Name = "chkbEnabled";
			this.chkbEnabled.TabIndex = 63;
			this.chkbEnabled.Text = "Enabled";
			// 
			// txtFilename
			// 
			this.txtFilename.Location = new System.Drawing.Point(120, 96);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(250, 20);
			this.txtFilename.TabIndex = 52;
			this.txtFilename.Text = "";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(120, 72);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(250, 20);
			this.txtTitle.TabIndex = 51;
			this.txtTitle.Text = "";
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(0, 72);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.TabIndex = 65;
			this.lblTitle.Text = "Title:";
			// 
			// lblFilename
			// 
			this.lblFilename.Location = new System.Drawing.Point(0, 96);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(120, 20);
			this.lblFilename.TabIndex = 64;
			this.lblFilename.Text = "Launching Application:";
			// 
			// buttonLaunchingApp
			// 
			this.buttonLaunchingApp.Location = new System.Drawing.Point(376, 96);
			this.buttonLaunchingApp.Name = "buttonLaunchingApp";
			this.buttonLaunchingApp.Size = new System.Drawing.Size(20, 20);
			this.buttonLaunchingApp.TabIndex = 53;
			this.buttonLaunchingApp.Text = "...";
			this.buttonLaunchingApp.Click += new System.EventHandler(this.buttonLaunchingApp_Click);
			// 
			// lblImgDirectories
			// 
			this.lblImgDirectories.Location = new System.Drawing.Point(0, 320);
			this.lblImgDirectories.Name = "lblImgDirectories";
			this.lblImgDirectories.TabIndex = 77;
			this.lblImgDirectories.Text = "Image directories:";
			// 
			// buttonFiledir
			// 
			this.buttonFiledir.Location = new System.Drawing.Point(376, 272);
			this.buttonFiledir.Name = "buttonFiledir";
			this.buttonFiledir.Size = new System.Drawing.Size(20, 20);
			this.buttonFiledir.TabIndex = 72;
			this.buttonFiledir.Text = "...";
			this.buttonFiledir.Click += new System.EventHandler(this.buttonFiledir_Click);
			// 
			// txtExtensions
			// 
			this.txtExtensions.Location = new System.Drawing.Point(120, 296);
			this.txtExtensions.Name = "txtExtensions";
			this.txtExtensions.Size = new System.Drawing.Size(250, 20);
			this.txtExtensions.TabIndex = 74;
			this.txtExtensions.Text = "";
			// 
			// txtImageDirs
			// 
			this.txtImageDirs.Location = new System.Drawing.Point(120, 320);
			this.txtImageDirs.Multiline = true;
			this.txtImageDirs.Name = "txtImageDirs";
			this.txtImageDirs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtImageDirs.Size = new System.Drawing.Size(250, 64);
			this.txtImageDirs.TabIndex = 71;
			this.txtImageDirs.Text = "txtImageDirs";
			// 
			// txtFiles
			// 
			this.txtFiles.Location = new System.Drawing.Point(120, 272);
			this.txtFiles.Name = "txtFiles";
			this.txtFiles.Size = new System.Drawing.Size(250, 20);
			this.txtFiles.TabIndex = 70;
			this.txtFiles.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 296);
			this.label4.Name = "label4";
			this.label4.TabIndex = 76;
			this.label4.Text = "File-Extensions:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 272);
			this.label2.Name = "label2";
			this.label2.TabIndex = 75;
			this.label2.Text = "File Directory:";
			// 
			// buttonImageDirs
			// 
			this.buttonImageDirs.Location = new System.Drawing.Point(376, 320);
			this.buttonImageDirs.Name = "buttonImageDirs";
			this.buttonImageDirs.Size = new System.Drawing.Size(20, 20);
			this.buttonImageDirs.TabIndex = 73;
			this.buttonImageDirs.Text = "...";
			this.buttonImageDirs.Click += new System.EventHandler(this.buttonImageDirs_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 32);
			this.label3.TabIndex = 78;
			this.label3.Text = "Directory-Browse";
			// 
			// AppSettingsDirBrowse
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblImgDirectories);
			this.Controls.Add(this.buttonFiledir);
			this.Controls.Add(this.txtExtensions);
			this.Controls.Add(this.txtImageDirs);
			this.Controls.Add(this.txtFiles);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonImageDirs);
			this.Controls.Add(this.chkbUseShellExecute);
			this.Controls.Add(this.chkbUseQuotes);
			this.Controls.Add(this.btnStartup);
			this.Controls.Add(this.txtStartupDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cbWindowStyle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtArguments);
			this.Controls.Add(this.lblArg);
			this.Controls.Add(this.lblImageFile);
			this.Controls.Add(this.buttonImagefile);
			this.Controls.Add(this.txtImageFile);
			this.Controls.Add(this.chkbEnabled);
			this.Controls.Add(this.txtFilename);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblFilename);
			this.Controls.Add(this.buttonLaunchingApp);
			this.Name = "AppSettingsDirBrowse";
			this.Size = new System.Drawing.Size(408, 416);
			this.Load += new System.EventHandler(this.AppSettingsDirBrowse_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override bool AppObj2Form(AppItem curApp)
		{
			this.chkbEnabled.Checked = curApp.Enabled;
			this.txtTitle.Text = curApp.Title;
			this.txtFilename.Text = curApp.Filename;
			this.txtArguments.Text = curApp.Arguments;
			SetWindowStyle(curApp.WindowStyle);
			this.txtStartupDir.Text = curApp.Startupdir;
			this.chkbUseShellExecute.Checked = (curApp.UseShellExecute);
			this.chkbUseQuotes.Checked = (curApp.UseQuotes);
			this.txtImageFile.Text = curApp.Imagefile;
			this.txtFiles.Text = curApp.FileDirectory;
			this.txtImageDirs.Text = curApp.ImageDirectory;
			this.txtExtensions.Text = curApp.ValidExtensions;
			return true;
		}


		public override void Form2AppObj(AppItem curApp)
		{
			curApp.Enabled = this.chkbEnabled.Checked;
			curApp.Title = this.txtTitle.Text;
			curApp.Filename = this.txtFilename.Text;
			curApp.Arguments = this.txtArguments.Text;
			curApp.WindowStyle = GetSelectedWindowStyle();
			curApp.Startupdir = this.txtStartupDir.Text;
			curApp.UseShellExecute = (this.chkbUseShellExecute.Checked);
			curApp.UseQuotes = (this.chkbUseQuotes.Checked);
			curApp.SourceType = myProgSourceType.DIRBROWSE;
			curApp.Imagefile = this.txtImageFile.Text;
			curApp.FileDirectory = this.txtFiles.Text;
			curApp.ImageDirectory = this.txtImageDirs.Text;
			curApp.ValidExtensions = this.txtExtensions.Text;
		}

		public override bool EntriesOK(AppItem curApp)
		{
			m_Checker.Clear();
			m_Checker.DoCheck(txtTitle.Text != "", "No title entered!");
			if (txtFilename.Text == "") 
			{
				m_Checker.DoCheck(chkbUseShellExecute.Checked, "No launching filename entered!");
			}
			m_Checker.DoCheck(txtFiles.Text != "", "No filedirectory entered!");
			m_Checker.DoCheck(txtExtensions.Text != "", "No file extensions entered!");

			if (!m_Checker.IsOk)
			{
				System.Windows.Forms.MessageBox.Show(m_Checker.Problems);
			}
			else
			{
			}
			return m_Checker.IsOk;
		}

		private void SetWindowStyle(ProcessWindowStyle val) 
		{
			switch (val)
			{
				case ProcessWindowStyle.Normal:
					cbWindowStyle.SelectedIndex = 0;
					break;
				case ProcessWindowStyle.Minimized:
					cbWindowStyle.SelectedIndex = 1;
					break;
				case ProcessWindowStyle.Maximized:
					cbWindowStyle.SelectedIndex = 2;
					break;
				case ProcessWindowStyle.Hidden:
					cbWindowStyle.SelectedIndex = 3;
					break;
			}

		}
		
		private ProcessWindowStyle GetSelectedWindowStyle()
		{
			if (this.cbWindowStyle.SelectedIndex == 1)
			{
				return ProcessWindowStyle.Minimized;
			}
			else if (this.cbWindowStyle.SelectedIndex == 2)
			{
				return ProcessWindowStyle.Maximized;
			} 
			else if (this.cbWindowStyle.SelectedIndex == 3)
			{
				return ProcessWindowStyle.Hidden;
			}
			else
				return ProcessWindowStyle.Normal;

		}

		private void AppSettingsDirBrowse_Load(object sender, System.EventArgs e)
		{
			// set tooltip-stuff..... 
			toolTip.SetToolTip(txtTitle, "This text will appear in the listitem of MediaPortal\r\n(mandatory)");
			toolTip.SetToolTip(txtFiles, "First directory to display in MediaPortal.\r\n(mandatory)");
			toolTip.SetToolTip(chkbUseShellExecute, "Enable this if you want to run a program that is associated with a specific file-" +
				"extension.\r\nYou can omit the \"Launching Application\" in this case.");
			toolTip.SetToolTip(chkbUseQuotes, "Quotes are usually needed to handle filenames with spaces correctly. \r\nAvoid double" +
				" quotes though!");
			toolTip.SetToolTip(txtStartupDir, "Optional path that is passed as the launch-directory \r\n\r\n(advanced hint: Use %FILEDIR" +
				"% if you want to use the directory where the launched file is stored)");
			toolTip.SetToolTip(cbWindowStyle, "Appearance of the launched program. \r\nTry HIDDEN or MINIMIZED for a seamless integr" +
				"ation in MediaPortal");
			toolTip.SetToolTip(txtArguments, "Optional arguments that are needed to launch the program \r\n\r\n(advanced hint: Use %FIL" +
				"E% if the filename needs to be placed in some specific place between several arg" +
				"uments)");
			toolTip.SetToolTip(txtImageFile, "Optional filename for an image to display in MediaPortal");
			toolTip.SetToolTip(chkbEnabled, "Only enabled items will appear in MediaPortal");
			toolTip.SetToolTip(txtFilename, "Program you wish to execute, include the full path (mandatory if ShellExecute is " +
				"OFF)");
			toolTip.SetToolTip(txtExtensions, "Only files with matching extensions will be displayed. \r\nSeparate several extension" +
				"s by a coma (.zip,.txt)\r\n(mandatory)");
			toolTip.SetToolTip(txtImageDirs, "Optional directory where MediaPortal searches for matching images. \r\n MediaPort" +
				"al will cycle through all the directories and display a mini-slideshow of all ma" +
				"tching images.");
		}

		private void buttonLaunchingApp_Click(object sender, System.EventArgs e)
		{
			dialogFile.FileName = txtFilename.Text;
			dialogFile.RestoreDirectory = true;
			if( dialogFile.ShowDialog(null) == DialogResult.OK )
			{
				txtFilename.Text = dialogFile.FileName;
			}
		}

		private void buttonImagefile_Click(object sender, System.EventArgs e)
		{
			dialogFile.FileName = txtImageFile.Text;
			dialogFile.RestoreDirectory = true;
			if( dialogFile.ShowDialog(null) == DialogResult.OK )
			{
				txtImageFile.Text = dialogFile.FileName;
			}
		}

		private void btnStartup_Click(object sender, System.EventArgs e)
		{
			dialogFolder.SelectedPath = txtStartupDir.Text;
			if( dialogFolder.ShowDialog( null ) == DialogResult.OK )
			{
				txtStartupDir.Text = dialogFolder.SelectedPath;
			}
		}

		private void buttonFiledir_Click(object sender, System.EventArgs e)
		{
			dialogFolder.SelectedPath = txtFiles.Text;
			if( dialogFolder.ShowDialog( null ) == DialogResult.OK )
			{
				txtFiles.Text = dialogFolder.SelectedPath;
			}
		}

		private void buttonImageDirs_Click(object sender, System.EventArgs e)
		{
			if (txtImageDirs.Text != "")
			{
				dialogFolder.SelectedPath = txtImageDirs.Lines[0];
			}
			if( dialogFolder.ShowDialog( null ) == DialogResult.OK )
			{
				txtImageDirs.Text = txtImageDirs.Text + "\r\n" + dialogFolder.SelectedPath;
			}
		}


	}
}

