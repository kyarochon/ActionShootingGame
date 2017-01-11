using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Mega.Battle.Controller {
	public class Goal : MonoBehaviour {
		// ゴールに触れたらステージクリア
		void OnTriggerEnter()
		{
			// シーン遷移中は何もしない
			if (GameManager.Instance.isTransitioningScene ()) {
				return;
			}

			// 次のシーンに移行
			GameManager.Instance.showLoadingScene();
		}
	}
}