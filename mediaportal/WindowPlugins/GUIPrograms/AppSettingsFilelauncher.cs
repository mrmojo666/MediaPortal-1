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
	public class AppSettingsFilelauncher : WindowPlugins.GUIPrograms.AppSettings
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkbUseShellExecute;
		private System.Windows.Forms.CheckBox chkbUseQuotes;
		private System.Windows.Forms.Button btnStartup;
		private System.Windows.Forms.TextBox txtStartupDir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbWindowStyle;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtArguments;
		private System.Windows.Forms.Label lblArg;
		private System.Windows.Forms.Label lblImageFile;
		private System.Windows.Forms.TextBox txtImageFile;
		private System.Windows.Forms.CheckBox chkbEnabled;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button buttonImagefile;
		private System.Windows.Forms.Button buttonLaunchingApp;
		private System.Windows.Forms.Button buttonEditFiles;
		private System.ComponentModel.IContainer components = null;


		public AppSettingsFilelauncher()
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
			this.label3 = new System.Windows.Forms.Label();
			this.chkbUseShellExecute = new System.Windows.Forms.CheckBox();
			this.chkbUseQuotes = new System.Windows.Forms.CheckBox();
			this.btnStartup = new System.Windows.Forms.Button();
			this.txtStartupDir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbWindowStyle = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
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
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.buttonEditFiles = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 32);
			this.label3.TabIndex = 79;
			this.label3.Text = "Filelaunch";
			// 
			// chkbUseShellExecute
			// 
			this.chkbUseShellExecute.Location = new System.Drawing.Point(120, 120);
			this.chkbUseShellExecute.Name = "chkbUseShellExecute";
			this.chkbUseShellExecute.Size = new System.Drawing.Size(176, 24);
			this.chkbUseShellExecute.TabIndex = 90;
			this.chkbUseShellExecute.Text = "Startup using ShellExecute";
			// 
			// chkbUseQuotes
			// 
			this.chkbUseQuotes.Checked = true;
			this.chkbUseQuotes.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkbUseQuotes.Location = new System.Drawing.Point(120, 240);
			this.chkbUseQuotes.Name = "chkbUseQuotes";
			this.chkbUseQuotes.Size = new System.Drawing.Size(184, 24);
			this.chkbUseQuotes.TabIndex = 89;
			this.chkbUseQuotes.Text = "Quotes around Filenames";
			// 
			// btnStartup
			// 
			this.btnStartup.Location = new System.Drawing.Point(376, 216);
			this.btnStartup.Name = "btnStartup";
			this.btnStartup.Size = new System.Drawing.Size(20, 20);
			this.btnStartup.TabIndex = 88;
			this.btnStartup.Text = "...";
			this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
			// 
			// txtStartupDir
			// 
			this.txtStartupDir.Location = new System.Drawing.Point(120, 216);
			this.txtStartupDir.Name = "txtStartupDir";
			this.txtStartupDir.Size = new System.Drawing.Size(250, 20);
			this.txtStartupDir.TabIndex = 87;
			this.txtStartupDir.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 216);
			this.label5.Name = "label5";
			this.label5.TabIndex = 97;
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
			this.cbWindowStyle.TabIndex = 86;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(0, 192);
			this.label6.Name = "label6";
			this.label6.TabIndex = 96;
			this.label6.Text = "Window-Style:";
			// 
			// txtArguments
			// 
			this.txtArguments.Location = new System.Drawing.Point(120, 168);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(250, 20);
			this.txtArguments.TabIndex = 85;
			this.txtArguments.Text = "";
			// 
			// lblArg
			// 
			this.lblArg.Location = new System.Drawing.Point(0, 168);
			this.lblArg.Name = "lblArg";
			this.lblArg.TabIndex = 95;
			this.lblArg.Text = "Arguments:";
			// 
			// lblImageFile
			// 
			this.lblImageFile.Location = new System.Drawing.Point(0, 144);
			this.lblImageFile.Name = "lblImageFile";
			this.lblImageFile.Size = new System.Drawing.Size(80, 20);
			this.lblImageFile.TabIndex = 94;
			this.lblImageFile.Text = "Imagefile:";
			// 
			// buttonImagefile
			// 
			this.buttonImagefile.Location = new System.Drawing.Point(376, 144);
			this.buttonImagefile.Name = "buttonImagefile";
			this.buttonImagefile.Size = new System.Drawing.Size(20, 20);
			this.buttonImagefile.TabIndex = 84;
			this.buttonImagefile.Text = "...";
			this.buttonImagefile.Click += new System.EventHandler(this.buttonImagefile_Click);
			// 
			// txtImageFile
			// 
			this.txtImageFile.Location = new System.Drawing.Point(120, 144);
			this.txtImageFile.Name = "txtImageFile";
			this.txtImageFile.Size = new System.Drawing.Size(250, 20);
			this.txtImageFile.TabIndex = 83;
			this.txtImageFile.Text = "";
			// 
			// chkbEnabled
			// 
			this.chkbEnabled.Checked = true;
			this.chkbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkbEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkbEnabled.Location = new System.Drawing.Point(8, 40);
			this.chkbEnabled.Name = "chkbEnabled";
			this.chkbEnabled.TabIndex = 91;
			this.chkbEnabled.Text = "Enabled";
			// 
			// txtFilename
			// 
			this.txtFilename.Location = new System.Drawing.Point(120, 96);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(250, 20);
			this.txtFilename.TabIndex = 81;
			this.txtFilename.Text = "";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(120, 72);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(250, 20);
			this.txtTitle.TabIndex = 80;
			this.txtTitle.Text = "";
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(0, 72);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.TabIndex = 93;
			this.lblTitle.Text = "Title:";
			// 
			// lblFilename
			// 
			this.lblFilename.Location = new System.Drawing.Point(0, 96);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(120, 20);
			this.lblFilename.TabIndex = 92;
			this.lblFilename.Text = "Launching Application:";
			// 
			// buttonLaunchingApp
			// 
			this.buttonLaunchingApp.Location = new System.Drawing.Point(376, 96);
			this.buttonLaunchingApp.Name = "buttonLaunchingApp";
			this.buttonLaunchingApp.Size = new System.Drawing.Size(20, 20);
			this.buttonLaunchingApp.TabIndex = 82;
			this.buttonLaunchingApp.Text = "...";
			this.buttonLaunchingApp.Click += new System.EventHandler(this.buttonLaunchingApp_Click);
			// 
			// buttonEditFiles
			// 
			this.buttonEditFiles.Location = new System.Drawing.Point(248, 264);
			this.buttonEditFiles.Name = "buttonEditFiles";
			this.buttonEditFiles.Size = new System.Drawing.Size(120, 24);
			this.buttonEditFiles.TabIndex = 108;
			this.buttonEditFiles.Text = "Edit Files...";
			this.buttonEditFiles.Click += new System.EventHandler(this.buttonEditFiles_Click);
			// 
			// AppSettingsFilelauncher
			// 
			this.Controls.Add(this.buttonEditFiles);
			this.Controls.Add(this.chkbUseShellExecute);
			this.Controls.Add(this.chkbUseQuotes);
			this.Controls.Add(this.btnStartup);
			this.Controls.Add(this.txtStartupDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cbWindowStyle);
			this.Controls.Add(this.label6);
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
			this.Controls.Add(this.label3);
			this.Name = "AppSettingsFilelauncher";
			this.Size = new System.Drawing.Size(408, 392);
			this.Load += new System.EventHandler(this.AppSettingsFilelauncher_Load);
			this.ResumeLayout(false);

		}
		#endregion

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


		private void AppSettingsFilelauncher_Load(object sender, System.EventArgs e)
		{
			// set tooltip-stuff..... 
			toolTip.SetToolTip(txtTitle, "This text will appear in the listitem of MediaPortal\r\n(mandatory)");
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
		
		}

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
			curApp.SourceType = myProgSourceType.FILELAUNCHER;
			curApp.Imagefile = this.txtImageFile.Text;
		}

		public override bool EntriesOK(AppItem curApp)
		{
			m_Checker.Clear();
			m_Checker.DoCheck(txtTitle.Text != "", "No title entered!");
			if (txtFilename.Text == "") 
			{
				m_Checker.DoCheck(chkbUseShellExecute.Checked, "No launching filename entered!");
			}

			if (!m_Checker.IsOk)
			{
				System.Windows.Forms.MessageBox.Show(m_Checker.Problems);
			}
			else
			{
			}
			return m_Checker.IsOk;
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

		private void buttonEditFiles_Click(object sender, System.EventArgs e)
		{
			FileButtonClicked();
		}

	}
}

