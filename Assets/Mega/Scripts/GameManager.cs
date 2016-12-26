
namespace Mega{
	public class GameManager {
		private static GameManager gameManager;

		private GameManager ()
		{

		}

		public static GameManager Instance 
		{
			get {
				if( gameManager == null ) gameManager = new GameManager();
				return gameManager;
			}
		}

	}

}