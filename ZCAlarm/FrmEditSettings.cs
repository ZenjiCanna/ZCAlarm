using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZCAlarm
{
	public partial class FrmEditSettings : Form
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrmEditSettings()
		{
			InitializeComponent();
		}

		/// <summary>
		/// フォーム Load イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmEditSettings_Load(object sender, EventArgs e)
		{
			this.txtSoundPath.Text = Properties.Settings.Default.DefaultSound;
		}

		/// <summary>
		/// 参照釦クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buRef_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = this.txtSoundPath.Text;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.txtSoundPath.Text = dialog.FileName;
			}
			this.txtSoundPath.Focus();
		}

		/// <summary>
		/// OKボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buOk_Click(object sender, EventArgs e)
		{
			string soundPath = this.txtSoundPath.Text;
			if (string.IsNullOrEmpty(soundPath)) {
				Properties.Settings.Default.DefaultSound = "";
			} else if (System.IO.File.Exists(soundPath)) {
				Properties.Settings.Default.DefaultSound = soundPath;
			} else {
				this.txtSoundPath.Focus();
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

	}
}
