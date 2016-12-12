using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// this.transform.position.z = character.transform.position.z; という書き方はできないので注意
		Vector3 pos = this.transform.position;
		pos.z = character.transform.position.z;
		this.transform.position = pos;
	}
}
