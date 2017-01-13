using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {
	public class Coin : MonoBehaviour {
		public int score = 100;

		void Start () {
			this.transform.Rotate (0, Random.Range (0, 360), 0);
		}

		void Update () {
			this.transform.Rotate (0, 3, 0);
		}

		void OnTriggerEnter(Collider other){
			// スコア加算
			GameManager.Instance.addScore (this.score);

			// 触れられたら破棄
			Destroy (this.gameObject);
		}

	}
}