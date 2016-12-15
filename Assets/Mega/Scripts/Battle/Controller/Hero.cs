using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {
	
	public class Hero : Character {
		override protected void Start()
		{
			this.upForce = 750.0f;
			base.Start ();
		}


		override protected void Update ()
		{
			// キー入力に応じて方向を変更
			if (Input.GetKey (KeyCode.RightArrow)) {
				moveDirection = Direction2D.Right;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				moveDirection = Direction2D.Left;
			} else {
				moveDirection = Direction2D.None;
			}

			// ジャンプ処理
			if (Input.GetKeyDown (KeyCode.Space)) {
				commandJump = true;
			} else {
				commandJump = false;
			}

			// 弾を撃つ
			if (Input.GetKeyDown (KeyCode.Z)) {
				commandBullet = true;
			} else {
				commandBullet = false;
			}

			base.Update ();
		}

		override public void damaged(int damage)
		{
			print ("Hero Damaged! : " + damage);
		}
	}
}