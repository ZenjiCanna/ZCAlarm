using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Globalization;
using System.IO;
using Cs = ZCAlarm.Constants;
using System.Collections;

namespace ZCAlarm
{
	public partial class MainForm : Form
	{

		// --------------------------------------------------------------------
		#region プロパティ
		// --------------------------------------------------------------------
		/// <summary>
		/// 保存タイマ定義リスト
		/// </summary>
		private List<TimerDef> defs;

		/// <summary>
		/// 最終インターバル処理時刻
		/// </summary>
		private DateTime lastCheckTime;
		#endregion

		// --------------------------------------------------------------------
		#region 初期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Form Load イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			// 一覧Viewの表示設定
			this.timerList.View = View.Details;
			this.timerList.Sorting = SortOrder.Ascending;
			this.timerList.ListViewItemSorter = new TimerListComparer();

			// 定義情報読み込み
			bool result = this.LoadSavedDefs();

			// 自動起動タイマーの起動
			this.InitCreateTimer();

			// メニュー項目の有効無効状態初期設定
			this.UpdateMenuItemEnabled();

			// インターバル処理開始
			Timer timer = new Timer();
			timer.Tick += new EventHandler(IntervalJob);
			timer.Interval = 200;
			timer.Enabled = true;
			this.intervelTimer = timer;
		}

		private Timer intervelTimer;

		/// <summary>
		/// Form Shown イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Shown(object sender, EventArgs e)
		{
			// Window表示位置再現
			this.RestoreWindowInfo();

			// 一覧先頭を選択状態とする
			if (this.timerList.Items.Count > 0) {
				this.timerList.Items[0].Selected = true;
			}
		}
		#endregion

		// --------------------------------------------------------------------
		#region 終了処理
		// --------------------------------------------------------------------
		/// <summary>
		/// Form Closing イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 定周期タイマーを無効にする
			this.intervelTimer.Enabled = false;

			// 定義情報保存
			this.SaveTimerDefs(null, this.defs);

			// インスタンス情報保存
			this.SaveTimerInstances(null);

			// Window表示位置保存
			this.SaveWindowInfo();
		}

		#endregion

		// --------------------------------------------------------------------
		#region 定義情報読み書き
		// --------------------------------------------------------------------
		/// <summary>
		/// 定義情報読み
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private List<TimerDef> LoadTimerDefs(string path)
		{
			if (path == null) {
				path = this.GetSettingPath("TimerDefs");
			}

			List<TimerDef> result = null;
			try {
				System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(SavedDefs));
				using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
					//読み込んで逆シリアル化する
					object obj = xs.Deserialize(fs);
					fs.Close();
					result = ((SavedDefs)obj).Defs;
				}
			} catch (Exception ex) {
				string exmessage = ex.ToString();
			}
			return result;
		}

		/// <summary>
		/// 定義情報書き
		/// </summary>
		/// <param name="path"></param>
		/// <param name="list"></param>
		/// <returns></returns>
		private bool SaveTimerDefs(string path, List<TimerDef> list)
		{
			bool result = true;

			if (path == null) {
				path = this.GetSettingPath("TimerDefs");
			}

			//XmlSerializerオブジェクトを作成
			//オブジェクトの型を指定する
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SavedDefs));

			try {
				//書き込むファイルを開く
				System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, FileAccess.Write);
				//シリアル化し、XMLファイルに保存する
				SavedDefs savelist = new SavedDefs();
				savelist.Defs = this.defs;
				serializer.Serialize(fs, savelist);
				//ファイルを閉じる
				fs.Close();
			} catch (Exception) {
				result = false;
			}
			return result;
		}

		#endregion

		// --------------------------------------------------------------------
		#region インスタンス情報読み書き
		// --------------------------------------------------------------------
		/// <summary>
		/// インスタンス情報読み
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private List<TimerInstance> LoadTimerInstances(string path)
		{
			if (path == null) {
				path = this.GetSettingPath("TimerInstances");
			}

			List<TimerInstance> result = null;
			try {
				System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(SavedInstance));
				using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
					//読み込んで逆シリアル化する
					object obj = xs.Deserialize(fs);
					fs.Close();
					result = ((SavedInstance)obj).Instances;
				}
			} catch (Exception ex) {
				string exmessage = ex.ToString();
			}
			return result;
		}

		/// <summary>
		/// インスタンス情報書き
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private bool SaveTimerInstances(string path)
		{
			bool result = true;

			if (path == null) {
				path = this.GetSettingPath("TimerInstances");
			}

			try {
				//XmlSerializerオブジェクトを作成
				//オブジェクトの型を指定する
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SavedInstance));

				//書き込むファイルを開く
				System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, FileAccess.Write);
				//シリアル化し、XMLファイルに保存する
				SavedInstance savelist = new SavedInstance();
				List<TimerInstance> instancelist = new List<TimerInstance>();
				foreach (ListViewItem item in this.timerList.Items) {
					instancelist.Add((TimerInstance)item.Tag);
				}
				savelist.Instances = instancelist;
				serializer.Serialize(fs, savelist);
				//ファイルを閉じる
				fs.Close();
			} catch (Exception e) {
				string message = e.Message;
				result = false;
			}
			return result;
		}

		#endregion

		// --------------------------------------------------------------------
		#region ウィンドウ情報
		// --------------------------------------------------------------------
		/// <summary>
		/// 保存している前回ウィンドウ情報から表示位置・サイズを再現する
		/// </summary>
		private void RestoreWindowInfo()
		{
			WindowInfo info = this.LoadWindowInfo();
			if (info != null) {
				this.Location = new Point(info.wx, info.wy);
				this.Size = new Size(info.wWidth, info.wHeight);
				this.timerList.Columns[0].Width = info.colWidthName;
				this.timerList.Columns[1].Width = info.colWidthTime;
				this.timerList.Columns[2].Width = info.colWidthMemo;
			}
		}

		/// <summary>
		/// ウィンドウ情報を読み込む
		/// </summary>
		/// <returns></returns>
		private WindowInfo LoadWindowInfo()
		{
			WindowInfo result = null;
			System.Xml.Serialization.XmlSerializer xs =	new System.Xml.Serialization.XmlSerializer(typeof(WindowInfo));

			try {
				string path = this.GetSettingPath("WindowInfo");
				FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
				//読み込んで逆シリアル化する
				object obj = xs.Deserialize(fs);
				fs.Close();
				result = (WindowInfo)obj;
			} catch (Exception) {
			}

			return result;
		}

		/// <summary>
		/// ウィンドウ情報を保存する
		/// </summary>
		/// <returns></returns>
		private bool SaveWindowInfo()
		{
			bool result = true;

			//保存先のファイル名
			string fileName = this.GetSettingPath("WindowInfo");

			//保存するクラスのインスタンスを作成
			WindowInfo info = new WindowInfo();
			info.wx = this.Location.X;
			info.wy = this.Location.Y;
			info.wWidth = this.Size.Width;
			info.wHeight = this.Size.Height;
			info.colWidthName = this.timerList.Columns[0].Width;
			info.colWidthTime = this.timerList.Columns[1].Width;
			info.colWidthMemo = this.timerList.Columns[2].Width;

			//XmlSerializerオブジェクトを作成
			//オブジェクトの型を指定する
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(WindowInfo));

			try {
				//書き込むファイルを開く
				System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, FileAccess.Write);
				//シリアル化し、XMLファイルに保存する
				serializer.Serialize(fs, info);
				//ファイルを閉じる
				fs.Close();
			} catch (Exception) {
				result = false;
			}
			return result;
		}

		/// <summary>
		/// 設定情報パスを作成（合成）する
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private string GetSettingPath(string fileName)
		{
			if (fileName == null) {
				fileName = Application.ProductName;
			}
			string appdata = Application.UserAppDataPath;
			string path = Path.Combine(
				Environment.GetFolderPath(
					Environment.SpecialFolder.ApplicationData),
				Application.CompanyName + "\\" + Application.ProductName +
				"\\" + fileName + ".config");
			return path;
		}
		#endregion

		// --------------------------------------------------------------------
		#region 定周期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// 定周期処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void IntervalJob(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			TimeSpan ts = now - this.lastCheckTime;
			if (ts.TotalSeconds < 1) {
				return;
			}

			foreach (ListViewItem item in this.timerList.Items) {
				TimerInstance instance = (TimerInstance)item.Tag;
				if (instance.State == TimerState.Run) {

					if (now > instance.UpTime) {
						instance.State = TimerState.Timeup;
						item.SubItems[1].Text = "TimeUp";

						SoundPlayer wavePlayer = this.ResolvedSound(instance);
						if (wavePlayer != null) {
							wavePlayer.Play();
						} else {
							System.Media.SystemSounds.Asterisk.Play();
						}
					} else {
						item.SubItems[1].Text = this.RemainCountDesc(instance.UpTime - now);
					}
				}
			}
			this.lastCheckTime = now;
		}
		#endregion

		// --------------------------------------------------------------------
		#region タイマー情報操作補助メソッド
		// --------------------------------------------------------------------
		/// <summary>
		/// タイマー定義情報を読み込む
		/// </summary>
		/// <returns>正常か</returns>
		private bool LoadSavedDefs()
		{
			List<TimerDef> list = this.LoadTimerDefs(null);
			if (list != null) {
				this.defs = list;
			} else {
				this.defs = new List<TimerDef>();
			}
			return true;
		}

		/// <summary>
		/// 自動開始となっているタイマーのインスタンスを生成し起動する
		/// </summary>
		private void InitCreateTimer()
		{

			foreach (TimerDef def in this.defs) {
				if (def.AutoStart) {
					TimerInstance instance = this.CreateTimerInstance(def);
					instance.Start();
					this.timerList.Items.Add(this.CreateViewItem(instance));
				}
			}
		}

		/// <summary>
		/// 定義情報からタイマーのインスタンスを生成する
		/// </summary>
		/// <param name="def"></param>
		/// <returns></returns>
		private TimerInstance CreateTimerInstance(TimerDef def)
		{
			TimerInstance instance = new TimerInstance(def);
			return instance;
		}

		#endregion

		// --------------------------------------------------------------------
		#region 画面表示関連補助メソッド
		// --------------------------------------------------------------------
		/// <summary>
		/// リストビューアイテムを作成する
		/// </summary>
		/// <param name="instance"></param>
		/// <returns></returns>
		private ListViewItem CreateViewItem(TimerInstance instance)
		{
			ListViewItem item = new ListViewItem();

			// タイマインスタンスは Tag に保持させる
			item.Tag = instance;

			// 名称
			item.Text = instance.Title;

			// 残り時間
			if (instance.State == TimerState.Run) {
				TimeSpan ts = instance.UpTime - DateTime.Now;
				item.SubItems.Add(this.RemainCountDesc(ts), Color.Black, SystemColors.Window, null);
			} else {
				if (instance.State == TimerState.Pause) {
					item.SubItems.Add("Pause");
				} else if (instance.State == TimerState.Timeup) {
					item.SubItems.Add("TimeUp");
				} else {
					item.SubItems.Add("");
				}
			}

			// メモ
			item.SubItems.Add(instance.Memo, Color.Black, SystemColors.Window, null);

			return item;
		}

		/// <summary>
		/// 残り時間の表示文字列を返す
		/// </summary>
		/// <param name="span">残り時間</param>
		/// <returns></returns>
		private string RemainCountDesc(TimeSpan span)
		{
			if (span.TotalDays >= 4) {
				return span.TotalDays.ToString() + "日";
			} else {
				return span.ToString(@"hh\:mm\:ss");
			}
		}

		/// <summary>
		/// ソート実行
		/// </summary>
		private void DoSoreList()
		{
			this.timerList.Sort();
		}

		///// <summary>
		///// タイマー定義からリストビューアイテムを探す
		///// </summary>
		///// <param name="def">タイマー定義</param>
		///// <param name="exceptItem">除外アイテム</param>
		///// <returns></returns>
		//private ListViewItem FindItem(TimerDef def, ListViewItem exceptItem)
		//{
		//    foreach (ListViewItem item in this.timerList.Items) {
		//        TimerInstance instance = (TimerInstance)item.Tag;
		//        if (instance.Def == def && item != exceptItem) {
		//            return item;
		//        }
		//    }
		//    return null;
		//}

		#endregion

		// --------------------------------------------------------------------
		#region サウンド関連処理
		// --------------------------------------------------------------------
		/// <summary>
		/// Windows のサウンドフォルダパスを返す
		/// </summary>
		/// <returns></returns>
		private string SystemSoundFolder()
		{
			return Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");
		}

		/// <summary>
		/// デフォルトのサウンドファイルパスを返す
		/// </summary>
		/// <returns>サウンドファイルパス</returns>
		private string GetDefaultSoundPath()
		{
			string path = Properties.Settings.Default.DefaultSound;
			if (string.IsNullOrEmpty(path)) {
				return null;
			}
			if (!System.IO.File.Exists(path)) {
				return null;
			}
			return path;
		}

		/// <summary>
		/// タイムアップ時のサウンドを決定しパスを返す
		/// </summary>
		/// <param name="instance">タイマーインスタンス</param>
		/// <returns>サウンドファイルパス</returns>
		private SoundPlayer ResolvedSound(TimerInstance instance)
		{
			string path = instance.Soundfile;
			
			// 設定サウンドファイルパスの存在確認
			if (!string.IsNullOrEmpty(path)) {
				if (!System.IO.File.Exists(path)) {
					path = this.GetDefaultSoundPath();
				}
			} else {
				path = this.GetDefaultSoundPath();
			}

			if (string.IsNullOrEmpty(path)) {
				return null;
			}
			return new SoundPlayer(path);
		}
	
		#endregion

		// --------------------------------------------------------------------
		#region 画面操作応答
		// --------------------------------------------------------------------
		/// <summary>
		/// ProcessCmdKey オーバーライド
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{

			if (keyData == Keys.Return) {
				this.OperateEditInstance();
				return true;
			} else if (keyData == Keys.Escape) {
				this.OperateStopTimer();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// コンテキストメニュー応答
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name) {
				case "miNewTimer":
					this.OperateNewTimer();
					break;
				case "miEditInstance":
					this.OperateEditInstance();
					break;
				case "miStop":							// 動作しているタイマを停止する
					this.OperateStopTimer();
					break;
				case "miStart":							// 再起動
					this.OperateStartTimer();
					break;
				case "miDel":
					this.OperateDeleteTimer();
					break;
				case "miSettings":
					this.OperateEditSettings();
					break;
				case "miAbout":
					(new AboutZCAlarmBox()).ShowDialog();
					break;
				case "miRestore":
					this.OperateRestore();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 前回終了時点の状態に復元
		/// </summary>
		private void OperateRestore()
		{
			List<TimerInstance> result = this.LoadTimerInstances(null);
			if (result == null) {
				MessageBox.Show("保存ﾃﾞｰﾀが読み込めません", "ｴﾗｰ", MessageBoxButtons.OK); 
				return;
			}
			if (MessageBox.Show("ﾀｲﾏｰﾘｽﾄを前回終了時点に戻します。現在起動しているﾀｲﾏｰは無効(削除)となります。よろしいですか？",
				"確認", MessageBoxButtons.OKCancel) == DialogResult.OK) {


				this.timerList.Items.Clear();			// 表示リストクリア
				foreach (TimerInstance instance in result) {
					this.timerList.Items.Add(this.CreateViewItem(instance));
				}
				// this.DoSoreList();
				this.UpdateMenuItemEnabled();
			}
		}

		/// <summary>
		/// 設定編集
		/// </summary>
		private void OperateEditSettings()
		{
			FrmEditSettings dialog = new FrmEditSettings();
			dialog.StartPosition = FormStartPosition.CenterParent;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.DoSoreList();
				this.UpdateMenuItemEnabled();
			}
		}

		/// <summary>
		/// タイマー再起動操作
		/// </summary>
		private void OperateStartTimer()
		{

			ListViewItem item = this.GetFirstSelectdItem();
			if (item != null) {

				TimerInstance instance = (TimerInstance)item.Tag;
				if (instance.State == TimerState.Timeup || instance.State == TimerState.Pause) {
					instance.Start();
					this.DoSoreList();
					this.UpdateMenuItemEnabled();
				}
			}
		}

		/// <summary>
		/// タイマインスタンス削除操作
		/// </summary>
		private void OperateDeleteTimer()
		{
			foreach (ListViewItem item in this.timerList.SelectedItems) {
				this.timerList.Items.Remove(item);
			}
			this.DoSoreList();
			this.UpdateMenuItemEnabled();
		}

		/// <summary>
		/// タイマ一次停止操作
		/// </summary>
		/// <param name="clearList">停止操作対象リストビューアイテムのリスト NULL なら選択中のアイテムが対象</param>
		private void OperateStopTimer(IList clearList = null)
		{
			if (clearList == null) {
				clearList = this.timerList.SelectedItems;
			}

			foreach (ListViewItem item in this.timerList.SelectedItems) {
				TimerInstance instance = (TimerInstance)item.Tag;
				instance.Pause();
				if (instance.State == TimerState.Pause) {
					item.SubItems[1].Text = "Pause";
				}
			}
			this.DoSoreList();
			this.UpdateMenuItemEnabled();
		}

		/// <summary>
		/// 新規カウントダウンタイマー作成
		/// </summary>
		private void OperateNewTimer()
		{

			FrmTimerSet dialog = new FrmTimerSet();
			dialog.StartPosition = FormStartPosition.CenterParent;
			dialog.Defs = this.defs;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				TimerDef def = dialog.EditTimerDef;
				TimerInstance instance = this.CreateTimerInstance(def);
				instance.Start();
				this.timerList.Items.Add(this.CreateViewItem(instance));
				this.DoSoreList();
				this.UpdateMenuItemEnabled();
			}
		}

		/// <summary>
		/// インスタンス情報を編集する
		/// </summary>
		private void OperateEditInstance()
		{
			// 選択行を取得する
			ListViewItem item = this.GetFirstSelectdItem();
			if (item == null) {
				return;
			}

			TimerInstance instance = (TimerInstance)item.Tag;
			if (this.SubEditInstance(instance)) {
				item.SubItems[0].Text = instance.Title;
				item.SubItems[2].Text = instance.Memo;

				this.DoSoreList();
				this.UpdateMenuItemEnabled();
			}
		}

		/// <summary>
		/// 動作中タイマーのプロパティー編集
		/// </summary>
		/// <param name="instance"></param>
		/// <returns></returns>
		private bool SubEditInstance(TimerInstance instance)
		{

			FrmTimerUpd dialog = new FrmTimerUpd();
			dialog.Type = instance.Type;
			int countOrg = instance.SetCount;
			if (instance.Type == Cs.TimerType.Alarm) {
				countOrg = instance.SetCount;
			} else {
				if (instance.State == TimerState.Run) {
					countOrg = instance.ToSeconds;
				} else {
					countOrg = instance.SetCount;
				}
			}
			dialog.SetCount = countOrg;
			dialog.Title = instance.Title;
			dialog.Memo = instance.Memo;
			dialog.Soundfile = instance.Soundfile;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {

				bool autoStart = (dialog.Type != instance.Type || dialog.SetCount != countOrg);		// 設定時刻などが変更されていたら自動的に起動する
				instance.Type = dialog.Type;
				instance.SetCount = dialog.SetCount;
				instance.Title = dialog.Title;
				instance.Memo = dialog.Memo;
				instance.Soundfile = dialog.Soundfile;
				if (instance.State == TimerState.Run || autoStart) {
					instance.Start();
				}
	
				return true;
			}
			return false;
		}

		/// <summary>
		/// 最初の選択行のタイマーインスタンスを返す
		/// </summary>
		/// <returns>選択行タイマーインスタンス、無い場合はnull</returns>
		private TimerInstance GetFirstSelectedInstance()
		{
			TimerInstance instance = null;
			ListViewItem item = this.GetFirstSelectdItem();
			if (item != null) {
				instance = (TimerInstance)item.Tag;
			}
			return instance;
		}

		/// <summary>
		/// 最初の選択行を返す
		/// </summary>
		/// <returns>選択行オブジェクト、無い場合はnull</returns>
		private ListViewItem GetFirstSelectdItem()
		{
			foreach (ListViewItem item in this.timerList.SelectedItems) {
				return item;
			}
			return null;
		}

		/// <summary>
		/// リストダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerList_DoubleClick(object sender, EventArgs e)
		{

			ListViewItem item = this.GetFirstSelectdItem();
			if (item != null) {
				TimerInstance instance = (TimerInstance)item.Tag;
				this.OperateEditInstance();
			}
		}

		/// <summary>
		/// リスト選択状態変化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateMenuItemEnabled();
		}

		/// <summary>
		/// メニュー項目の有効無効を切り替える
		/// </summary>
		private void UpdateMenuItemEnabled()
		{
			int selCount = this.timerList.SelectedItems.Count;
			bool isItemSelected = selCount > 0;
			bool isMultiSelected = selCount > 1;
			bool isSingleSelected = selCount == 1;
			TimerInstance selinstance = null;
			if (isItemSelected) {
				selinstance = (TimerInstance)this.timerList.SelectedItems[0].Tag;
			}
			bool isTimerSelected = false;
			foreach (ListViewItem item in this.timerList.SelectedItems) {
				if (((TimerInstance)item.Tag).Type == TimerDef.cTypeTimer) {
					isTimerSelected = true;
					break;
				}
			}

			this.miDel.Enabled = isItemSelected;
			this.miEditInstance.Enabled = isSingleSelected;
			this.miStart.Enabled = isSingleSelected && selinstance.State != TimerState.Run;
			this.miStop.Enabled = isTimerSelected;
		}

		#endregion

	}
}
