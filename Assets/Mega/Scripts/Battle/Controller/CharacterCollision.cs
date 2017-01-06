using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {
	public class CharacterCollision : MonoBehaviour {
		public int CollisionDamage = 10;

		// 敵に触れたらダメージ
		void OnTriggerEnter()
		{
			Character characterController =  this.GetComponentInParent<Character> ();
			characterController.damaged (CollisionDamage);
		}

	}
}