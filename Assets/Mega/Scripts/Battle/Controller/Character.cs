using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Character : MonoBehaviour {
		public GameObject bulletPrefab;

		protected Direction2D moveDirection;
		protected Direction2D faceDirection;

		protected bool commandJump;
		protected bool commandBullet;


		protected float upForce = 500.0f;
		protected float turnForce = 500.0f;
		protected Rigidbody myRigidbody;

		// Use this for initialization
		protected void Start () {
			myRigidbody = this.GetComponent<Rigidbody> ();

			moveDirection = Direction2D.None;
			faceDirection = Direction2D.Right;
			commandJump = false;
		}

		// Update is called once per frame
		protected void Update () {
			// 移動
			this.move ();

			// ジャンプ
			if (commandJump) {
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



		public void damaged(int damage)
		{
			print ("Character Damaged! : " + damage);
		}
	}
}



