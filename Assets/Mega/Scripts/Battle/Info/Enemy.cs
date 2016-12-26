
namespace Mega.Battle.Info {
	public class Enemy : Character {
		private EnemyParam param;
		private int currentHp;

		// 初期化
		public void Init(EnemyParam param)
		{
			this.param = param;
			this.currentHp = param.hp;
		}


		// Characterをoverride
		public override void setCurrentHp(int hp)
		{
			this.currentHp = hp;
		}


		public override int getMaxHp()
		{
			return param.hp;
		}

		public override int getCurrentHp()
		{
			return this.currentHp;
		}

		public override int getAttack()
		{
			return param.attack;
		}

		public override int getDefense()
		{
			return 0;
		}

		public override float getUpForce()
		{
			return param.upForce;
		}

		public override float getTurnForce()
		{
			return param.turnForce;
		}

		public override float getScale()
		{
			return param.scale;
		}
	}

}