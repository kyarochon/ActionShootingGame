using UnityEngine;
using System.Collections;

namespace Mega{
	public class LoadingInitializer : MonoBehaviour {

		// ロード画面が表示されたらシーン切り替え
		void Awake() {
			GameManager.Instance.transitionNextScene ();
		}
	}
}