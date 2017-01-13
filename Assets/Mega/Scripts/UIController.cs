using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Mega {
	public class UIController : MonoBehaviour {
		// UIコントローラ
		public GameObject hpText;
		public GameObject shadowHpText;
		public GameObject centerText;
		public GameObject scoreText;
		public GameObject shadowScoreText;

		private Battle.Info.Hero heroInfo;

		void Awake()
		{
			this.heroInfo = Battle.Info.Hero.Instance;
		}

		void Update ()
		{
			// 情報に変動があれば表示更新
			if (heroInfo.hasUpdatedInfo ()) {
				this.updateHpText ();
			}
			if (GameManager.Instance.hasUpdatedScore) {
				this.updateScoreText ();
			}
		}


		private void updateHpText()
		{
			// HP表示更新
			string text = this.getHpText ();
			this.hpText.GetComponent<Text> ().text = text;
			this.shadowHpText.GetComponent<Text> ().text = text;

			// ゲームオーバー
			if (!heroInfo.isAlive ()) {
				this.centerText.GetComponent<Text> ().text = "GAME OVER";
			} else {
				this.centerText.GetComponent<Text> ().text = "";
			}
		}

		private void updateScoreText()
		{
			// スコア表示更新
			int score = GameManager.Instance.getScore();
			this.scoreText.GetComponent<Text> ().text = score.ToString ();
			this.shadowScoreText.GetComponent<Text> ().text = score.ToString ();
		}


		private string getHpText()
		{
			int currentHp = heroInfo.getCurrentHp ();
			int maxHp = heroInfo.getMaxHp ();

			string text = "HP：";
			for (int i = 10; i <= maxHp; i+=10) {
				if (currentHp >= i) {
					text += "■";
				} else {
					text += "□";
				}
			}
			return text;
		}

		// ボタンイベント
		public void LeftButtonDown()   { GameManager.Instance.LeftButtonDown (); }
		public void LeftButtonUp()     { GameManager.Instance.LeftButtonUp (); }
		public void RightButtonDown()  { GameManager.Instance.RightButtonDown ();  }
		public void RightButtonUp()    { GameManager.Instance.RightButtonUp (); }
		public void UpButtonDown()     { GameManager.Instance.UpButtonDown ();  }
		public void AttackButtonDown() { GameManager.Instance.AttackButtonDown ();  }
	}
}
