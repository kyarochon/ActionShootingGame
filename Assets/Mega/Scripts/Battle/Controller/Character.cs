using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Character : MonoBehaviour {
		public GameObject bulletPrefab;

		protected Direction2D moveDirection = Direction2D.None;
		protected Direction2D faceDirection = Direction2D.Right;

		protected bool commandJump;
		protected bool commandBullet;
		protected bool isGround;

		protected float upForce = 500.0f;
		protected float turnForce = 500.0f;

		protected int hp = 1;
		protected int attack = 1;

		protected Rigidbody myRigidbody;

		// Use this for initialization
		virtual protected void Start () {
			myRigidbody = this.GetComponent<Rigidbody> ();

			commandJump = false;
			isGround = true;
		}

		// Update is called once per frame
		virtual protected void Update () {
			// 移動
			this.move ();

			// ジャンプ
			if (commandJump && isGround) {
				this.myRigidbody.AddForce (this.transform.up * this.upForce);
			}

			// 弾を打つ
			if (commandBullet) {
				GameObject bullet = Instantiate (bulletPrefab) as GameObject;
				Bullet bulletScript = bullet.GetComponent<Bullet> ();
				bulletScript.init (faceDirection, this.transform.position);
			}
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
					this.myRigidbody.AddForce (0, 0, this.turnForce);
					this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
					this.faceDirection = Direction2D.Right;
					break;
				}

				// 移動(左)
				case Direction2D.Left:
				{
					this.myRigidbody.AddForce (0, 0, -this.turnForce);
					this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
					this.faceDirection = Direction2D.Left;
					break;
				}
			}
		}


		virtual public void damaged(int damage)
		{
			print ("Character Damaged! : " + damage);
		}


		void OnTriggerEnter()
		{
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



