using UnityEngine;
using System.Collections;

// ******************************
// *    ゲームの初期化を担当       *
// ******************************

namespace Mega{
	public class GameInitializer : MonoBehaviour {

		void Awake() {
			// 最初のステージを読み込み
			GameManager.Instance.showLoadingScene ();
		}
	}
}