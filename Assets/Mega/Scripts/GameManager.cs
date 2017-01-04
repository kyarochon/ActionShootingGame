using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ******************************
//  ゲーム全体を管理
//  ・ステージ進行状況を管理   
// ******************************

namespace Mega{
	public class GameManager : MonoBehaviour{
		private static GameManager gameManager;
		private int stageSceneIndex = 0;
		private bool shouldUnloadPrevScene = false;

		private GameManager ()
		{
			this.stageSceneIndex = 0;
		}

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

		public void transitionNextScene()
		{
			if (shouldUnloadPrevScene) {
				print ("GameManager::transitionNextScene 2回連続で呼ばれてる！");
				return;
			}

			// 次のシーンを読み込み
			this.stageSceneIndex++;
			SceneManager.LoadScene ("GameStageScene_0" + this.stageSceneIndex, LoadSceneMode.Additive);

			// 次フレームで今のシーンを破棄
			shouldUnloadPrevScene = true;
		}


		void Update()
		{
			if (shouldUnloadPrevScene) {
				SceneManager.UnloadScene ("GameStageScene_0" + (this.stageSceneIndex - 1));
				shouldUnloadPrevScene = false;
			}
		}

	}

}