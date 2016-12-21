using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	// UIコントローラ
	public GameObject hpText;
	public GameObject gameManagerObj;

	// ゲームマネージャ
	private GameManager gameManager;



	void Start ()
	{
		this.gameManager = this.GetComponent<GameManager> ();
	}


	void Update ()
	{
	}


	public void updateHpText()
	{
		//		hpText.GetComponent<Text>().text = "hogehoge";
	}


}
