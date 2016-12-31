using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	private Scene stageScene;


	void Start () {
		SceneManager.LoadScene ("GameStageScene_03", LoadSceneMode.Additive);
		stageScene = SceneManager.GetSceneByName ("GameStageScene_03");
	}
}
