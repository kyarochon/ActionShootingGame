
namespace Mega.Battle {
	public class BattleManager  {
		private static BattleManager battleManager;

		private BattleManager ()
		{
		}

		public static BattleManager Instance 
		{
			get {
				if( battleManager == null ) battleManager = new BattleManager();
				return battleManager;
			}
		}
	}


}
