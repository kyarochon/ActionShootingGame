using UnityEngine;
using System.Collections;

public class GameSceneLoader : MonoBehaviour {
	void Start () {
		Application.LoadLevelAdditive("GameScene");	
	}
}
