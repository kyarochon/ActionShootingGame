using UnityEngine;
using System.Collections;

// ******************************
// *    ステージ毎の初期化を担当    *
// ******************************

namespace Mega{

	public class StageInitializer : MonoBehaviour {
		public GameObject heroPrefab;

		private GameObject hero;
		private Mega.Battle.Controller.Hero heroController;
		private Vector3 cameraPos;

		// ステージの初期化処理はすべてここで行う
		void Awake()
		{
			// カメラの初期位置を記憶
			cameraPos = this.transform.position;

			// Heroの配置
			Vector3 position = new Vector3(0.0f, 0.0f, 125.0f);
			Quaternion rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
			hero = Instantiate (heroPrefab, position, rotation) as GameObject;
			GameManager.Instance.moveGameObjectToCurrentScene (hero);

			// コントローラを保持
			heroController = hero.GetComponent<Mega.Battle.Controller.Hero>();

			// GameManagerに登録
			GameManager.Instance.setStageInitializer(this);
		}

		void Start()
		{
			GameManager.Instance.hideLoadingScene ();
		}

		void Update()
		{
			// カメラ位置調整
			this.adjustCameraPosition();
		}


		private void adjustCameraPosition()
		{
			Vector3 pos = this.transform.position;

			// Z座標は常に追従
			pos.z = hero.transform.position.z;

			// Y座標はカメラの高さ-10よりも高い位置にいれば追従
			if (hero.transform.position.y > cameraPos.y - 10.0f) {
				pos.y = hero.transform.position.y + 10.0f;
			} else {
				pos.y = cameraPos.y;
			}

			this.transform.position = pos;
		}

		public void restartStage()
		{
			// 位置を初期化
			hero.transform.position = new Vector3(0.0f, 0.0f, 125.0f);
		}

		public void LeftButtonDown()   { this.heroController.LeftButtonDown (); }
		public void LeftButtonUp()     { this.heroController.LeftButtonUp (); }
		public void RightButtonDown()  { this.heroController.RightButtonDown ();  }
		public void RightButtonUp()    { this.heroController.RightButtonUp (); }
		public void UpButtonDown()     { this.heroController.UpButtonDown ();  }
		public void AttackButtonDown() { this.heroController.AttackButtonDown ();  }
	}

}