using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Enemy : Character {


		protected float moveDuration   = 0.0f;
		protected float jumpDuration   = 0.0f;
		protected float bulletDuration = 0.0f;
		protected EnemyParam enemyParam;

		public void Init(EnemyParam param) {
			faceDirection = Direction2D.Left;

			this.enemyParam = param;
			this.hp = param.hp;
			this.attack = param.attack;
			this.upForce = param.upForce;
			this.turnForce = param.turnForce;
			this.transform.localScale = new Vector3 (param.scale, param.scale, param.scale);

			this.moveDuration   = param.moveDuration;
			this.jumpDuration   = param.jumpDuration;
			this.bulletDuration = param.bulletDuration;
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
			print ("Enemy Damaged! : " + damage);
			this.hp -= damage;
			if (this.hp <= 0)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
