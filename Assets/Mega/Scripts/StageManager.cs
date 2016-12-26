using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	public GameObject heroPrefab;

	private GameObject hero;
	private Vector3 cameraPos;

	// ステージの初期化処理はすべてここで行う
	void Awake()
	{
		// カメラの初期位置を記憶
		cameraPos = this.transform.position;

		// Heroの配置
		Vector3 position = new Vector3(0.0f, 0.0f, 1.8f);
		Quaternion rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		hero = Instantiate (heroPrefab, position, rotation) as GameObject;

		// Enemyの取得


	}


	void Update()
	{
		// カメラ位置調整
		this.adjustCameraPosition();
	}


	private void adjustCameraPosition()
	{
		Vector3 pos = this.transform.position;

		// Z座標は常に追従
		pos.z = hero.transform.position.z;

		// Y座標はカメラの高さよりも高い位置にいれば追従
		if (hero.transform.position.y > cameraPos.y) {
			pos.y = hero.transform.position.y;
		} else {
			pos.y = cameraPos.y;
		}

		this.transform.position = pos;
	}

}
