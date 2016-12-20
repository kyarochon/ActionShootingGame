using UnityEngine;
using System.Collections;

namespace Mega.Battle.Info {
	abstract public class Character {
		public abstract void setCurrentHp (int hp);

		public abstract int getMaxHp ();
		public abstract int getCurrentHp ();
		public abstract int getAttack ();
		public abstract int getDefense ();
		public abstract float getUpForce ();
		public abstract float getTurnForce ();
		public abstract float getScale();
	}

}
