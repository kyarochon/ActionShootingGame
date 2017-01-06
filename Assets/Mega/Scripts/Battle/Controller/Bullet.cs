using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {
	public class Bullet : MonoBehaviour {
		protected float lifeTime 	 = 1.0f;	// 生存秒数
		protected float DefaultSpeed = 3000.0f;	// 速度
		protected int damage   		 = 10;		// 当たった時のダメージ


		public void init(Direction2D direction, Vector3 position) {
			float speed = DefaultSpeed;
			switch (direction) {
			case Direction2D.Right:
				this.transform.position = position + new Vector3 (0, 3.0f, 1.0f);
				break;
			case Direction2D.Left:
				this.transform.position = position + new Vector3 (0, 3.0f, -1.0f);
				this.transform.Rotate (new Vector3 (0,180,0));
				break;
			case Direction2D.None:
				speed = 0.0f;
				this.transform.position = position;
				break;
			}

			this.GetComponent<Rigidbody> ().AddForce (transform.right * speed);
		}



		// Update is called once per frame
		void Update () {
			lifeTime -= Time.deltaTime;
			if (lifeTime <= 0) {
				Destroy (this.gameObject);
			}
		}


		void OnTriggerEnter(Collider other){
			Character character = other.GetComponent<Character> ();
			if (character) {
				character.damaged (this.damage);
			}

			// 弾は破壊
			Destroy (this.gameObject);
		}
	}
}