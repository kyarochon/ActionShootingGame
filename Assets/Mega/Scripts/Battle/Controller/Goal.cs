using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Mega.Battle.Controller {
	public class Goal : MonoBehaviour {
		private bool hasLoadedNextScene = false;

		// ゴールに触れたらステージクリア
		void OnTriggerEnter()
		{
			// 2回呼び出されるのを防止
			if (hasLoadedNextScene) {
				return;
			}
			hasLoadedNextScene = true;

			// 次のシーンに移行
			GameManager.Instance.transitionNextScene();
		}
	}
}