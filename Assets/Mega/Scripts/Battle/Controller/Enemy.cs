using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Enemy : Character {
		protected float moveDuration   = 0.0f;
		protected float jumpDuration   = 0.0f;
		protected float bulletDuration = 0.0f;
		protected EnemyParam enemyParam;

		public void Init(EnemyParam param) {
			// EnemyInfo初期化
			Info.Enemy enemyInfo = new Info.Enemy ();
			enemyInfo.Init (param);
			this.characterInfo = enemyInfo;

			this.enemyParam = param;
			this.moveDuration   = param.moveDuration;
			this.jumpDuration   = param.jumpDuration;
			this.bulletDuration = param.bulletDuration;
			this.faceDirection = Direction2D.Left;
		}
			
		protected override void Update () {
			if (moveDuration > 0.0f) {
				moveDuration -= Time.deltaTime;
				if (moveDuration <= 0.0f) {
					this.moveDirection = (Direction2D)Random.Range (0, 3);
					moveDuration = this.enemyParam.moveDuration;
				}
			}

			commandJump = false;
			commandBullet = false;

			if (bulletDuration > 0.0f) {
				bulletDuration -= Time.deltaTime;
				if (bulletDuration <= 0.0f) {
					commandBullet = true;
					bulletDuration = this.enemyParam.bulletDuration;
				}
			}

			if (jumpDuration > 0.0f) {
				jumpDuration -= Time.deltaTime;
				if (jumpDuration <= 0.0f) {
					commandJump = true;
					jumpDuration = this.enemyParam.jumpDuration;
				}
			}

			base.Update ();
		}

		override public void damaged(int damage) 
		{
			base.damaged (damage);

			this.playHitEffect ();
			if (this.characterInfo.getCurrentHp () <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
