using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

namespace Mega.Battle.Controller {
	
	public class Hero : Character {
		private float invincibleTime = 0.0f;
		private bool isVisible = true;
		private bool isLeftButtonDown   = false;
		private bool isRightButtonDown  = false;
		private bool isJumpButtonDown   = false;
		private bool isAttackButtonDown = false;

		override protected void Start()
		{
			// TODO: 初期化処理はInit関数に移す
			// HeroInfo初期化
			this.characterInfo = Info.Hero.Instance;
			base.Start ();
		}


		override protected void Update ()
		{
			// 死亡していたら何も出来ない
			if (!this.characterInfo.isAlive ()) {
				
				// ジャンプor攻撃ボタンを押したらリスタート
				if (Input.GetKeyDown (KeyCode.Space) || isJumpButtonDown || Input.GetKeyDown (KeyCode.Z) || isAttackButtonDown){
					this.modelController.setIsVisible (true);
					this.characterInfo.setCurrentHp (100);
					GameManager.Instance.restartCurrentScene ();
				}

				return;
			}


			// 無敵時間を減らす
			if (invincibleTime > 0.0f) {
				invincibleTime -= Time.deltaTime;
				if (invincibleTime <= 0.0f) {
					invincibleTime = 0.0f;
				}
			}

			// キー入力に応じて方向を変更
			if (Input.GetKey (KeyCode.RightArrow) || isRightButtonDown) {
				moveDirection = Direction2D.Right;
			} else if (Input.GetKey (KeyCode.LeftArrow) || isLeftButtonDown) {
				moveDirection = Direction2D.Left;
			} else {
				moveDirection = Direction2D.None;
			}

			// ジャンプ処理
			if (Input.GetKeyDown (KeyCode.Space) || isJumpButtonDown) {
				commandJump = true;
			} else {
				commandJump = false;
			}
			isJumpButtonDown = false;

			// 弾を撃つ
			if (Input.GetKeyDown (KeyCode.Z) || isAttackButtonDown) {
				commandBullet = true;
			} else {
				commandBullet = false;
			}
			isAttackButtonDown = false;

			base.Update ();
		}


		// Collision
		override protected void OnCollisionEnter(Collision col)
		{
			if (col.gameObject.tag == "Enemy") {
				this.damaged (10);
			}
			base.OnCollisionEnter (col);
		}

		override protected void OnCollisionExit(Collision col) {
			base.OnCollisionExit (col);
		}




		override public void damaged(int damage)
		{
			// 無敵時間中or既に死んでいる場合にはダメージを受けない
			if (invincibleTime > 0.0f || !this.characterInfo.isAlive()) {
				return;
			}

			base.damaged (damage);

			// 生存時：無敵時間に入る
			if (this.characterInfo.isAlive ()) {
				invincibleTime = 2.0f;
				StartCoroutine (invincibleBlink ());

			// 死亡時：エフェクトを出して非表示に
			} else {
				this.playHitEffect ();
				this.modelController.setIsVisible (false);
			}

		}



		IEnumerator invincibleBlink()
		{
			while (invincibleTime > 0.0f) {
				this.modelController.setIsVisible (this.isVisible);
				this.isVisible = !this.isVisible;

				yield return new WaitForSeconds (0.1f);
			}

			this.modelController.setIsVisible (true);
		}

		public void LeftButtonDown()   { this.isLeftButtonDown   = true;  }
		public void LeftButtonUp()     { this.isLeftButtonDown   = false; }
		public void RightButtonDown()  { this.isRightButtonDown  = true;  }
		public void RightButtonUp()    { this.isRightButtonDown  = false; }
		public void UpButtonDown()     { this.isJumpButtonDown   = true;  }
		public void AttackButtonDown() { this.isAttackButtonDown = true;  }
	}
}