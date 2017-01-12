using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ******************************
//  ゲーム全体を管理
//  ・ステージ進行状況を管理   
// ******************************

namespace Mega{
	public class GameManager : MonoBehaviour{
		private const int MAX_SCENE_INDEX = 3;

		private static GameManager gameManager;
		private int stageSceneIndex = 0;
		private string loadSceneName = "";
		private string unloadSceneName = "";
		private StageInitializer stageInitializer = null;
		private Scene currentScene;

		// フェード用
		private Texture2D blackTexture;
		private float fadeAlpha = 0;
		private bool isFading = false;



		public static GameManager Instance 
		{
			get {
				if (gameManager == null) {
					GameObject gameObject = new GameObject("GameManager");
					gameManager = gameObject.AddComponent<GameManager>();
					gameManager.init ();
				}
				return gameManager;
			}
		}


		private GameManager (){}
		private void init()
		{
			this.stageSceneIndex = 0;
			this.loadSceneName = "";
			this.unloadSceneName = "";

			// 黒テクスチャ生成
			this.blackTexture = new Texture2D (32, 32, TextureFormat.RGB24, false);
			this.blackTexture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
			this.blackTexture.SetPixel (0, 0, Color.white);
			this.blackTexture.Apply ();
		}


		// 現在のシーン名を取得
		private string getCurrentSceneName()
		{
			if (this.stageSceneIndex > 0) {
				return "GameStageScene_0" + this.stageSceneIndex;
			} else {
				return "";
			}
		}


		// 現在の初期化スクリプトを設定
		public void setStageInitializer(StageInitializer initialiser)
		{
			this.stageInitializer = initialiser;
		//	this.hideLoadingScene ();
		}


		public bool isTransitioningScene()
		{
			return this.isFading;
		}

		// フェードアウト＆ロード画面表示
		public void showLoadingScene()
		{
			StartCoroutine (FadeOut (1.0f));
		}

		// シーンを切り替え
		public void transitionNextScene()
		{
			// 最後のシーンなら最初からやり直し
			if (this.stageSceneIndex == MAX_SCENE_INDEX) {
				this.restartCurrentScene ();
				this.hideLoadingScene ();
				return;
			}

			// 次フレームでステージシーン切り替え
			this.unloadSceneName = getCurrentSceneName();
			this.stageSceneIndex++;
			this.loadSceneName = getCurrentSceneName ();
		}

		// フェードイン＆ロード画面非表示
		public void hideLoadingScene()
		{
			StartCoroutine (FadeIn (1.0f));
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
			if (this.loadSceneName.Length > 0) {
				SceneManager.LoadScene (getCurrentSceneName(), LoadSceneMode.Additive);
				this.currentScene = SceneManager.GetSceneByName (this.loadSceneName);
				this.loadSceneName = "";
			}

			if (this.unloadSceneName.Length > 0) {
				SceneManager.UnloadScene (unloadSceneName);
				this.unloadSceneName = "";
			}
		}


		void OnGUI()
		{
			if (!this.isFading)
				return;

			//透明度を更新して黒テクスチャを描画
			GUI.color = new Color (0, 0, 0, this.fadeAlpha);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.blackTexture);
		}


		private IEnumerator FadeOut (float interval)
		{
			// だんだん暗く
			this.isFading = true;
			float time = 0;
			while (time <= interval) {
				this.fadeAlpha = Mathf.Lerp (0f, 1f, time / interval);      
				time += Time.deltaTime;
				yield return 0;
			}

			// ロード画面を表示
			SceneManager.LoadScene ("LoadingScene", LoadSceneMode.Additive);
		}


		private IEnumerator FadeIn (float interval)
		{
			yield return new WaitForSeconds (0.5f);

			// ロード画面を非表示
			SceneManager.UnloadScene("LoadingScene");

			//だんだん明るく
			float time = 0;
			while (time <= interval) {
				this.fadeAlpha = Mathf.Lerp (1f, 0f, time / interval);
				time += Time.deltaTime;
				yield return 0;
			}
			this.isFading = false;

		}


		public void moveGameObjectToCurrentScene(GameObject gameObject)
		{
			SceneManager.MoveGameObjectToScene (gameObject, this.currentScene);
		}


		// ボタンイベント
		public void LeftButtonDown()   { this.stageInitializer.LeftButtonDown (); }
		public void LeftButtonUp()     { this.stageInitializer.LeftButtonUp (); }
		public void RightButtonDown()  { this.stageInitializer.RightButtonDown ();  }
		public void RightButtonUp()    { this.stageInitializer.RightButtonUp (); }
		public void UpButtonDown()     { this.stageInitializer.UpButtonDown ();  }
		public void AttackButtonDown() { print ("A!");this.stageInitializer.AttackButtonDown ();  }
	}

}