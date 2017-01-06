using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Mega.Battle.Controller {
	public class Goal : MonoBehaviour {
		// ゴールに触れたらステージクリア
		void OnTriggerEnter()
		{
			// 次のシーンに移行
			GameManager.Instance.transitionNextScene();
		}
	}
}