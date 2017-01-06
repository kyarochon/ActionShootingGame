using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ******************************
//  ゲーム全体を管理
//  ・ステージ進行状況を管理   
// ******************************

namespace Mega{
	public class GameManager : MonoBehaviour{
		private const int MAX_SCENE_INDEX = 2;

		private static GameManager gameManager;
		private int stageSceneIndex = 0;
		private string unloadSceneName = "";
		private StageInitializer stageInitializer = null;

		public static GameManager Instance 
		{
			get {
				if (gameManager == null) {
					GameObject gameObject = new GameObject("GameManager");
					gameManager = gameObject.AddComponent<GameManager>();
				}
				return gameManager;
			}
		}


		private GameManager ()
		{
			this.stageSceneIndex = 0;
			this.unloadSceneName = "";
		}


		// 現在のシーン名を取得
		private string getCurrentSceneName()
		{
			return "GameStageScene_0" + this.stageSceneIndex;
		}


		// 現在の初期化スクリプトを設定
		public void setStageInitializer(StageInitializer initialiser)
		{
			this.stageInitializer = initialiser;
		}

		// 次のステージに移行
		public void transitionNextScene()
		{
			// 最後のシーンなら最初からやり直し
			if (this.stageSceneIndex == MAX_SCENE_INDEX) {
				this.restartCurrentScene ();
				return;
			}

			// 次フレームで今のシーンを破棄
			this.unloadSceneName = getCurrentSceneName();

			// 次のシーンを読み込み
			this.stageSceneIndex++;
			SceneManager.LoadScene (getCurrentSceneName(), LoadSceneMode.Additive);
		}


		// 同ステージ最初から
		public void restartCurrentScene()
		{
			// TODO パラメータ初期化

			// 再度開始
			this.stageInitializer.restartStage ();
		}


		void Update()
		{
			if (this.unloadSceneName.Length > 0) {
				SceneManager.UnloadScene (unloadSceneName);
				this.unloadSceneName = "";
			}
		}

	}

}