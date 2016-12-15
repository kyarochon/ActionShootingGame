using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public float maxZ    = 5.0f;
	public float speedZ  = 1.0f;
	public float degreeZ = 0.0f; 

	public float maxY    = 0.0f;
	public float speedY  = 0.0f;
	public float degreeY = 0.0f;


	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		float posZ = maxZ * Mathf.Cos (Time.time * speedZ + Mathf.Deg2Rad * degreeZ);
		float posY = maxY * Mathf.Sin (Time.time * speedY + Mathf.Deg2Rad * degreeY);
		this.transform.position = startPos + transform.forward * posZ + transform.up * posY;
	}
}
