using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private Scene stageScene;


	void Start () {
		SceneManager.LoadScene ("GameScene", LoadSceneMode.Additive);
		stageScene = SceneManager.GetSceneByName("GameScene");
	}
}
