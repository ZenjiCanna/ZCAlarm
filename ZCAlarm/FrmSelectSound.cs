using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ZCAlarm
{
	/// <summary>
	/// サウンド選択フォームクラス
	/// </summary>
	public partial class FrmSelectSound : Form
	{
		// --------------------------------------------------------------------
		#region プロパティ
		// --------------------------------------------------------------------
		/// <summary>
		/// サウンドファイルパス
		/// </summary>
		private string filepath;
		public string Filepath
		{
			get { return this.filepath; }
			set { this.filepath = value; }
		}

		#endregion

		// --------------------------------------------------------------------
		#region 初期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrmSelectSound()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Form Load イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmSelectSound_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.filepath)) {
				this.txtPath.Text = this.filepath;
			}
		}

		#endregion

		// --------------------------------------------------------------------
		#region 終了処理
		// --------------------------------------------------------------------
		/// <summary>
		/// OKボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buOK_Click(object sender, EventArgs e)
		{
			if (this.CheckInput()) {
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		#endregion

		// --------------------------------------------------------------------
		#region 操作応答
		// --------------------------------------------------------------------
		/// <summary>
		/// 参照釦クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buRef_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = this.txtPath.Text;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.txtPath.Text = dialog.FileName;
			}
			this.txtPath.Focus();
		}

		/// <summary>
		/// 鳴らす釦クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buPlay_Click(object sender, EventArgs e)
		{
			string path = this.txtPath.Text;
			if (string.IsNullOrEmpty(path)) {
				return;
			}
			if (!System.IO.File.Exists(path)) {
				return;
			}

			SoundPlayer wavePlayer = new SoundPlayer(path);
			wavePlayer.Play();
		}

		#endregion

		// --------------------------------------------------------------------
		#region 補助処理
		// --------------------------------------------------------------------
		/// <summary>
		/// 入力をチェックする
		/// </summary>
		/// <returns>入力正常か</returns>
		private bool CheckInput()
		{
			if (!string.IsNullOrEmpty(this.txtPath.Text)) {
				if (!System.IO.File.Exists(this.txtPath.Text)) {
					this.txtPath.Focus();
					return false;
				}
			}

			this.filepath = this.txtPath.Text;
			return true;
		}


		#endregion

		
	
	}
}
