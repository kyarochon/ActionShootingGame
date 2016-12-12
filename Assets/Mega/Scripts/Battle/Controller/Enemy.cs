using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Enemy : Character {


		protected float moveDuration = 3.0f;
		protected float commandDuration = 2.0f;


		// Use this for initialization
		new void Start () {
			turnForce = 300.0f;

			base.Start ();
		}

		// Update is called once per frame
		new void Update () {
			if (moveDuration > 0) {
				moveDuration -= Time.deltaTime;
			} else {
				this.moveDirection = (Direction2D)Random.Range (0, 3);
				moveDuration = 5.0f;
			}


			if (commandDuration > 0) {
				commandDuration -= Time.deltaTime;
				commandJump = false;
				commandBullet = false;
			} else {
				int random = Random.Range (0, 2);
				if (random == 0) {
					commandJump = true;
				} else if (random == 1) {
					commandBullet = true;
				}
				commandDuration = 2.0f;
			}


			base.Update ();
		}

		new public void damaged(int damage)
		{
			print ("Enemy Damaged! : " + damage);
//			Destroy (this.gameObject);
		}
	}
}
