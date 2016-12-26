using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	private Scene stageScene;


	void Start () {
		SceneManager.LoadScene ("GameScene", LoadSceneMode.Additive);
		stageScene = SceneManager.GetSceneByName ("GameScene");
	}
}
