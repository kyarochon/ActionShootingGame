using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Mega {
	public class UIController : MonoBehaviour {
		// UIコントローラ
		public GameObject hpText;

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
			hpText.GetComponent<Text> ().text = "HP：" + heroInfo.getCurrentHp ();
		}


	}
}
