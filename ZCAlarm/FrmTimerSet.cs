using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cs = ZCAlarm.Constants;

namespace ZCAlarm
{
	public partial class FrmTimerSet : Form
	{
		// --------------------------------------------------------------------
		#region 属性・プロパティーなど
		// --------------------------------------------------------------------
		/// <summary>
		/// タイマー定義リスト
		/// </summary>
		public IList<TimerDef> Defs { get; set; }

		/// <summary>
		/// 編集したタイマー情報 OK の時だけ有効
		/// </summary>
		public TimerDef EditTimerDef { get; set; }

		#endregion

		// --------------------------------------------------------------------
		#region 初期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrmTimerSet()
		{
			this.Defs = new List<TimerDef>();
			InitializeComponent();
		}

		/// <summary>
		/// OnLoad オーバーライド
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// 一覧Viewの表示設定
			this.lstDefs.View = View.Details;

			foreach (TimerDef tdef in this.Defs) {
				this.lstDefs.Items.Add(this.CreateViewItem(tdef));
			}
			this.UpdateMenuItemEnabled();
		}
		#endregion

		// --------------------------------------------------------------------
		#region 終了処理
		// --------------------------------------------------------------------
		private void buOK_Click(object sender, EventArgs e)
		{
			TimerDef def;
			if (this.CheckInput(out def)) {
				this.EditTimerDef = def;
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		/// <summary>
		/// OnClosed オーバーライド
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			// タイマー定義並べ替えを反映する
			this.Defs.Clear();
			foreach (ListViewItem item in this.lstDefs.Items) {
				this.Defs.Add((TimerDef)item.Tag);
			}
		}

		#endregion


		// --------------------------------------------------------------------
		#region 補助処理
		// --------------------------------------------------------------------
		/// <summary>
		/// 入力をチェックする
		/// </summary>
		/// <returns>入力正常か</returns>
		private bool CheckInput(out TimerDef outDef)
		{
			outDef = null;

			TimerDef input = new TimerDef();
			input.Memo = this.txMemo.Text;
			input.Name = this.txTitle.Text;
			input.AutoStart = false;
			input.Type = this.ucTimeSet.TimeSetType;
			input.SetCount = this.ucTimeSet.InputValue;
			input.Soundfile = this.txSoundPath.Text;

			if (input.Type == Cs.TimerType.Timer) {
				if (input.SetCount < 1) {
					this.ucTimeSet.Focus();
					return false;
				}
			}

			outDef = input;
			return true;
		}

		/// <summary>
		/// リストビューアイテムを作成する
		/// </summary>
		/// <param name="tdef">タイマー定義</param>
		/// <returns></returns>
		private ListViewItem CreateViewItem(TimerDef tdef)
		{
			ListViewItem item = new ListViewItem();

			// タイマインスタンスは Tag に保持させる
			item.Tag = tdef;

			// 名称
			item.Text = tdef.Name;

			if (tdef.AutoStart) {
				item.SubItems.Add("自動");
			} else {
				item.SubItems.Add("");
			}
			return item;
		}


		/// <summary>
		/// 最初の選択行のタイマーインスタンスを返す
		/// </summary>
		/// <returns>選択行タイマーインスタンス、無い場合はnull</returns>
		private TimerDef GetFirstSelectedTemplate()
		{
			TimerDef tdef = null;
			ListViewItem item = this.GetFirstSelectdItem();
			if (item != null) {
				tdef = (TimerDef)item.Tag;
			}
			return tdef;
		}

		/// <summary>
		/// 最初の選択行を返す
		/// </summary>
		/// <returns>選択行オブジェクト、無い場合はnull</returns>
		private ListViewItem GetFirstSelectdItem()
		{
			foreach (ListViewItem item in this.lstDefs.SelectedItems) {
				return item;
			}
			return null;
		}


		#endregion

		// --------------------------------------------------------------------
		#region 画面操作応答
		// --------------------------------------------------------------------
		/// <summary>
		/// テンプレートに追加釦
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buAddTemplate_Click(object sender, EventArgs e)
		{
			TimerDef tdef;
			if (this.CheckInput(out tdef)) {
				this.Defs.Add(tdef);
				this.lstDefs.Items.Add(this.CreateViewItem(tdef));
			}
		}

		/// <summary>
		/// テンプレート修正釦
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buUpdTemplate_Click(object sender, EventArgs e)
		{
			ListViewItem lvItem = this.GetFirstSelectdItem();
			if (lvItem != null) {
				TimerDef tdef = (TimerDef)lvItem.Tag;
				TimerDef inputdef;
				if (this.CheckInput(out inputdef)) {
					tdef.Memo = inputdef.Memo;
					tdef.Name = inputdef.Name;
					tdef.SetCount = inputdef.SetCount;
					tdef.Soundfile = inputdef.Soundfile;
					tdef.Type = inputdef.Type;
					lvItem.Text = tdef.Name;
				}
			}
		}

		/// <summary>
		/// サウンド参照釦
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buSound_Click(object sender, EventArgs e)
		{

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = this.txSoundPath.Text;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.txSoundPath.Text = dialog.FileName;
			}
		}

		/// <summary>
		/// テンプレート選択行変化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstDefs_SelectedIndexChanged(object sender, EventArgs e)
		{

			// 選択テンプレートの内容をタイマー情報各欄に設定
			if (this.lstDefs.SelectedItems.Count == 1) {
				TimerDef tdef = this.GetFirstSelectedTemplate();
				this.txTitle.Text = tdef.Name;
				this.txMemo.Text = tdef.Memo;
				this.ucTimeSet.SetCount(tdef.Type, tdef.SetCount);
				this.txSoundPath.Text = tdef.Soundfile;

				if (this.ucTimeSet.ContainsFocus) {
					this.ucTimeSet.SetFocusCounter();
				} else if (this.txTitle.Focused) {
					this.txTitle.SelectAll();
				}
			}

			this.UpdateMenuItemEnabled();
		}

		/// <summary>
		/// メニュー項目の有効無効を切り替える
		/// </summary>
		private void UpdateMenuItemEnabled()
		{
			int selCount = this.lstDefs.SelectedItems.Count;
			bool isItemSelected = selCount > 0;
			bool isMultiSelected = selCount > 1;
			bool isSingleSelected = selCount == 1;

			// 自動起動のチェック設定 ：選択タイマー全部自動起動でチェック
			bool startAutoAll = false;
			if (isItemSelected) {
				startAutoAll = true;
				foreach (ListViewItem item in this.lstDefs.SelectedItems) {
					if (!((TimerDef)item.Tag).AutoStart) {
						startAutoAll = false;
						break;
					}
				}
			}
			this.miAutoStart.Checked = startAutoAll;

			// メニューの有効設定
			this.miDelTemplate.Enabled = isItemSelected;
			this.miMoveBottom.Enabled = isItemSelected;
			this.miMoveTop.Enabled = isItemSelected;
			this.miAutoStart.Enabled = isItemSelected;
			this.buUpdTemplate.Enabled = isSingleSelected;
		}


		/// <summary>
		/// ProcessCmdKey オーバーライド
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{

			if (keyData == Keys.Down) {
				if (this.IsUpDownTemplateChangeable()) {
					this.SelectNextTemplate();
					return true;
				}
			} else if (keyData == Keys.Up) {
				if (this.IsUpDownTemplateChangeable()) {
					this.SelectPrevTemplate();
					return true;
				}
			} else if (keyData == Keys.Escape) {
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// 上下キーでテンプレート切り替えをやっていい状況かを返す
		/// </summary>
		/// <returns></returns>
		private bool IsUpDownTemplateChangeable()
		{
			if (this.txMemo.Focused) {
				return false;
			}
			if (this.lstDefs.Focused) {
				return false;
			}
			return true;
		}


		/// <summary>
		/// 現在選択中テンプレートの次のテンプレートを選択する
		/// </summary>
		private void SelectNextTemplate()
		{

			int selectIndex = 0;
			ListViewItem firstItem = this.GetFirstSelectdItem();
			if (firstItem != null) {
				selectIndex = firstItem.Index + 1;
			}
			if (selectIndex >= this.lstDefs.Items.Count) {
				return;
			}
			this.SelectSingleTemplate(selectIndex);
		}

		/// <summary>
		/// 現在選択中テンプレートの前のテンプレートを選択する
		/// </summary>
		private void SelectPrevTemplate()
		{

			int selectIndex = 0;
			ListViewItem firstItem = this.GetFirstSelectdItem();
			if (firstItem != null) {
				selectIndex = firstItem.Index - 1;
			}
			if (selectIndex < 0) {
				return;
			}
			this.SelectSingleTemplate(selectIndex);
		}

		/// <summary>
		/// テンプレートリスト中で指定の１行を選択状態にする
		/// </summary>
		/// <param name="p_index"></param>
		private void SelectSingleTemplate(int p_index)
		{
			for (int i = 0; i < this.lstDefs.Items.Count; i++) {
				if (i == p_index) {
					this.lstDefs.Items[i].Selected = true;
				} else {
					this.lstDefs.Items[i].Selected = false;
				}
			}
		}

		/// <summary>
		/// コンテキストメニュー選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name) {
				case "miDelTemplate":
					this.OperateDeleteTemplate();
					break;
				case "miMoveTop":
					this.OperateTemplateMoveTop();
					break;
				case "miMoveBottom":
					this.OperateTemplateMoveBottom();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 選択テンプレートを削除する
		/// </summary>
		private void OperateDeleteTemplate()
		{

			if (this.lstDefs.SelectedItems.Count == 0) {
				return;
			}

			if (MessageBox.Show("選択テンプレートを削除してよろしいですか？", "削除確認", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {

				// メモリにあるテンプレートリストから削除する
				foreach (ListViewItem item in this.lstDefs.SelectedItems) {
					TimerDef tdef = (TimerDef)item.Tag;
					this.Defs.Remove(tdef);
				}

				// リストビューからも削除する
				while (this.lstDefs.SelectedItems.Count > 0) {
					this.lstDefs.Items.Remove(this.lstDefs.SelectedItems[0]);
				}
			}
		}

		/// <summary>
		/// 選択されているテンプレートをリストの最初に移動
		/// </summary>
		private void OperateTemplateMoveTop()
		{
			if (this.lstDefs.SelectedItems.Count == 0) {
				return;
			}

			// 選択アイテムの中で一番下のアイテムを探す
			ListViewItem lastSelectedItem = null;
			foreach (ListViewItem lvItem in this.lstDefs.SelectedItems) {
				if (lastSelectedItem == null) {
					lastSelectedItem = lvItem;
				} else if (lastSelectedItem.Index < lvItem.Index) {
					lastSelectedItem = lvItem;
				}
			}

			// 上の方にある非選択アイテムを選択アイテムの後ろに移動する
			while (lastSelectedItem.Index >= this.lstDefs.SelectedItems.Count) {
				for (int i = lastSelectedItem.Index - 1; i >= 0 ; i--) {
					if (!this.lstDefs.Items[i].Selected) {
						int insertpos = lastSelectedItem.Index;
						ListViewItem moveItem = this.lstDefs.Items[i];
						this.lstDefs.Items.RemoveAt(i);
						this.lstDefs.Items.Insert(insertpos, moveItem);
						break;
					}
				}
			}
		}

		/// <summary>
		/// 選択されているテンプレートをリストの最後に移動
		/// </summary>
		private void OperateTemplateMoveBottom()
		{
			if (this.lstDefs.SelectedItems.Count == 0) {
				return;
			}

			// 選択アイテムの中で一番上のアイテムを探す
			ListViewItem firstSelectedItem = null;
			foreach (ListViewItem lvItem in this.lstDefs.SelectedItems) {
				if (firstSelectedItem == null) {
					firstSelectedItem = lvItem;
				} else if (firstSelectedItem.Index > lvItem.Index) {
					firstSelectedItem = lvItem;
				}
			}

			// 下の方にある非選択アイテムを選択アイテムの前ろに移動する
			int nonSelectedItemsCount = this.lstDefs.Items.Count - this.lstDefs.SelectedItems.Count;
			while (firstSelectedItem.Index < nonSelectedItemsCount) {
				for (int i = firstSelectedItem.Index + 1; i < this.lstDefs.Items.Count; i++) {
					if (!this.lstDefs.Items[i].Selected) {
						int insertpos = firstSelectedItem.Index;
						ListViewItem moveItem = this.lstDefs.Items[i];
						this.lstDefs.Items.RemoveAt(i);
						this.lstDefs.Items.Insert(insertpos, moveItem);
						break;
					}
				}
			}
		}

		/// <summary>
		/// 自動起動設定メニュークリック応答
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void miAutoStart_Click(object sender, EventArgs e)
		{

			bool startAuto = !this.miAutoStart.Checked;
			foreach (ListViewItem item in this.lstDefs.SelectedItems) {
				TimerDef def = (TimerDef)item.Tag;
				def.AutoStart = startAuto;
				if (startAuto) {
					item.SubItems[1].Text = "自動";
				} else {
					item.SubItems[1].Text = "";
				}
			}
			this.miAutoStart.Checked = startAuto;
		}

		/// <summary>
		/// メモ欄でのリンククリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			// クリックされたリンクを開く
			System.Diagnostics.Process.Start(e.LinkText);
		}

		/// <summary>
		/// Memoテキストエディタ Enterイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_Enter(object sender, EventArgs e)
		{
			// Enter が改行になるように デフォルト釦を一時的になしにする
			this.AcceptButton = null;
		}

		/// <summary>
		/// Memoテキストエディタ Leaveイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_Leave(object sender, EventArgs e)
		{
			this.AcceptButton = this.buOK;
		}
		#endregion

	}
}
