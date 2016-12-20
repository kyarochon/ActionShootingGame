using UnityEngine;
using System.Collections;

namespace Mega.Battle.Info {

	public class Hero : Character {
		private int maxHp = 10;
		private int currentHp = 10;
		private int attack = 1;
		private int defense = 0;
		private float upForce = 750.0f;
		private float turnForce = 500.0f;
		private float scale = 1.0f;

		// 初期化
		public void Init()
		{
			this.currentHp = this.maxHp;
		}


		// Characterをoverride
		public override void setCurrentHp(int hp)
		{
			this.currentHp = hp;
		}


		public override int getMaxHp()
		{
			return this.maxHp;
		}

		public override int getCurrentHp()
		{
			return this.currentHp;
		}

		public override int getAttack()
		{
			return this.attack;
		}

		public override int getDefense()
		{
			return this.defense;
		}

		public override float getUpForce()
		{
			return this.upForce;
		}

		public override float getTurnForce()
		{
			return this.turnForce;
		}

		public override float getScale()
		{
			return scale;
		}
	}
}
