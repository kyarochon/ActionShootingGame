using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Mega {
	public class UIController : MonoBehaviour {
		// UIコントローラ
		public GameObject hpText;
		public GameObject centerText;

		private Battle.Info.Hero heroInfo;

		void Awake()
		{
			this.heroInfo = Battle.Info.Hero.Instance;
		}

		void Update ()
		{
			// 情報に変動があれば表示更新
			if (heroInfo.hasUpdatedInfo()) {
				this.updateHpText ();
			}
		}


		public void updateHpText()
		{
			int currentHp = heroInfo.getCurrentHp ();
			int maxHp = heroInfo.getMaxHp ();
			this.hpText.GetComponent<Text> ().text = " HP：" + currentHp + " / " + maxHp;

			// ゲームオーバー
			if (currentHp <= 0) {
				this.centerText.GetComponent<Text> ().text = "GAME OVER";
			}

		}


	}
}
