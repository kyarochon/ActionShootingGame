using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {
	public class Stage : MonoBehaviour {
		public float maxX    = 0.0f;
		public float speedX  = 0.0f;
		public float degreeX = 0.0f;

		public float maxY    = 0.0f;
		public float speedY  = 0.0f;
		public float degreeY = 0.0f;

		public float maxZ    = 0.0f;
		public float speedZ  = 0.0f;
		public float degreeZ = 0.0f; 

		private Vector3 startPos;

		// Use this for initialization
		void Start () {
			startPos = this.transform.position;
		}

		// Update is called once per frame
		void Update () {
			float posX = maxX * Mathf.Sin (Time.time * speedX + Mathf.Deg2Rad * degreeX);
			float posY = maxY * Mathf.Sin (Time.time * speedY + Mathf.Deg2Rad * degreeY);
			float posZ = maxZ * Mathf.Cos (Time.time * speedZ + Mathf.Deg2Rad * degreeZ);

			this.transform.position = startPos + new Vector3 (posX, posY, posZ);
		}
	}
}