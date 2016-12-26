using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	private Scene stageScene;


	void Start () {
		SceneManager.LoadScene ("GameStageScene_02", LoadSceneMode.Additive);
		stageScene = SceneManager.GetSceneByName ("GameStageScene_02");
	}
}
