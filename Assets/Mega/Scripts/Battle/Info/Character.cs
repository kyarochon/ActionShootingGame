
namespace Mega.Battle.Info {
	abstract public class Character {
		public abstract void setCurrentHp (int hp);


		public void damaged(int damage)
		{
			int currentHp = this.getCurrentHp () - damage;
			if (currentHp < 0) {
				currentHp = 0;
			}
			
			this.setCurrentHp (currentHp);
		}

		public bool isAlive()
		{
			return this.getCurrentHp() > 0;
		}

		public abstract int getMaxHp ();
		public abstract int getCurrentHp ();
		public abstract int getAttack ();
		public abstract int getDefense ();
		public abstract float getUpForce ();
		public abstract float getTurnForce ();
		public abstract float getScale();
		public abstract float getMaxSpeed();
	}

}
