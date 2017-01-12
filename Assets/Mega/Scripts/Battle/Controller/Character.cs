using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Character : MonoBehaviour {
		public GameObject bulletPrefab;
		public GameObject model;
		public GameObject hitEffect;
		private GameObject bulletObject = null;


		protected Direction2D moveDirection = Direction2D.None;
		protected Direction2D faceDirection = Direction2D.Right;

		protected bool commandJump;
		protected bool commandBullet;
		protected bool isGround;

		protected Info.Character characterInfo;
		protected Rigidbody myRigidbody;
		protected Mega.Battle.Controller.Model modelController;

		// Use this for initialization
		virtual protected void Start () {
			myRigidbody = this.GetComponent<Rigidbody> ();
			modelController = model.GetComponent<Mega.Battle.Controller.Model> ();

			commandJump = false;
			isGround = true;
		}

		// Update is called once per frame
		virtual protected void Update () {
			// シーン遷移中は何も出来ない
			if (GameManager.Instance.isTransitioningScene ()) {
				return;
			}

			// 移動
			this.move ();

			// ジャンプ
			if (commandJump && isGround) {
				this.myRigidbody.AddForce (this.transform.up * this.characterInfo.getUpForce ());
			}


			// 弾を打つ
			if (commandBullet && bulletObject == null) {
				bulletObject = Instantiate (bulletPrefab) as GameObject;
				GameManager.Instance.moveGameObjectToCurrentScene (bulletObject);
				Bullet bulletScript = bulletObject.GetComponent<Bullet> ();
				bulletScript.init (faceDirection, this.transform.position);
			}

			// アニメーション遷移
			this.modelController.setIsJump(!isGround);
			this.modelController.setSpeed (this.myRigidbody.velocity.magnitude);
		}

		protected void move()
		{
			// 移動
			switch (moveDirection) {

				// 停止
				case Direction2D.None:
				{
					break;
				}

				// 移動(右)
				case Direction2D.Right:
				{
					this.myRigidbody.AddForce (0, 0, this.characterInfo.getTurnForce (), ForceMode.Acceleration);
					this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
					this.faceDirection = Direction2D.Right;
					break;
				}

				// 移動(左)
				case Direction2D.Left:
				{
					this.myRigidbody.AddForce (0, 0, -this.characterInfo.getTurnForce (), ForceMode.Acceleration);
					this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
					this.faceDirection = Direction2D.Left;
					break;
				}
			}

			Vector3 velocity = this.myRigidbody.velocity;
			if (Mathf.Abs(velocity.z) > this.characterInfo.getMaxSpeed ()) {
				if (velocity.z > 0) {
					velocity.z = this.characterInfo.getMaxSpeed ();
				} else {
					velocity.z = -this.characterInfo.getMaxSpeed ();
				}
				this.myRigidbody.velocity = velocity;
			}

		}


		virtual public void damaged(int damage)
		{
			// HP変動
			this.characterInfo.damaged (damage);
		}

		protected void playHitEffect()
		{
			// ヒットエフェクト再生
			GameObject effect = Instantiate (this.hitEffect, transform.position, Quaternion.identity) as GameObject;
			effect.transform.localPosition = transform.position + new Vector3 (0.0f, 1.5f, 0.0f);
			Destroy (effect, 0.3f);
		}


		// Collision
		virtual protected void OnCollisionEnter(Collision col)
		{
			if (col.gameObject.tag == "MoveStage") {
				transform.SetParent (col.transform);
			}
		}

		virtual protected void OnCollisionExit(Collision col) {
			if (col.gameObject.tag == "MoveStage") {
				transform.SetParent (null);
			}
		}



		// Trigger
		void OnTriggerEnter()
		{
			isGround = true;
		}

		void OnTriggerStay(Collider collider)
		{
			isGround = true;
		}

		void OnTriggerExit()
		{
			isGround = false;
		}

	}
}
