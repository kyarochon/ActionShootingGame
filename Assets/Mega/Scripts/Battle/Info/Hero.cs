
namespace Mega.Battle.Info {
	public class Hero : Character {
		private static Hero heroInfo = null;

		private int maxHp = 1000;
		private int currentHp = 1000;
		private int attack = 1;
		private int defense = 0;
		private float upForce = 2000.0f;
		private float turnForce = 150.0f;
		private float scale = 1.0f;
		private bool updatedInfo = false;

		private Hero()
		{
			this.currentHp = this.maxHp;
		}

		public static Hero Instance 
		{
			get {
				if( heroInfo == null ) heroInfo = new Hero();
				return heroInfo;
			}
		}

		public bool hasUpdatedInfo()
		{
			if (updatedInfo) {
				updatedInfo = false;
				return true;
			} else {
				return false;
			}
		}



		// Characterをoverride
		public override void setCurrentHp(int hp)
		{
			this.currentHp = hp;
			this.updatedInfo = true;
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

		public override float getMaxSpeed()
		{
			return 30.0f;
		}
	}
}
