using UnityEngine;
using System.Collections;


namespace Mega.Battle {

	public class EnemyGenerator : MonoBehaviour {
		public GameObject enemyPrefab;
		public EnemyParam enemyParam;	// 生成される敵データ
		public int maxEnemy = 1;
		public float generateDuration = 3.0f;
		GameObject[] existEnemyList;

		void Start () {
			existEnemyList = new GameObject[maxEnemy];
			StartCoroutine (Exec ());
		}



		IEnumerator Exec()
		{
			while (true) {
				Generate ();
				yield return new WaitForSeconds (generateDuration);
			}
		}

		void Generate(){
			for (int i = 0; i < existEnemyList.Length; i++) {
				if (existEnemyList [i] == null) {
					GameObject enemy = Instantiate (enemyPrefab, transform.position, transform.rotation) as GameObject;
					enemy.GetComponent<Mega.Battle.Controller.Enemy> ().Init (enemyParam);
					existEnemyList [i] = enemy;
					return;
				}
			}
		}

	}

}

