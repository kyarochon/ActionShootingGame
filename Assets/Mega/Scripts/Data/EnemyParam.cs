using UnityEngine;

[CreateAssetMenu]
public class EnemyParam : ScriptableObject {

//	public enum MoveType
//	{
//		Headlong,	// 壁に当たるまで直進
//		RoundTrip	// 一定範囲を往復
//	};

	public int hp = 10;		// HP
	public int attack = 1;	// 攻撃力

	public float turnForce = 500.0f;	// 左右への速度
	public float upForce   = 500.0f;	// 上へのジャンプ力
	public float scale     = 1.0f;		// サイズ

	public float jumpDuration   = 2.0f;	// ジャンプする頻度
	public float bulletDuration = 2.0f;	// 弾を撃つ頻度
	public float moveDuration   = 3.0f;	// 移動する頻度


	// public EnemyShape shape;			// 形
	// public Color color;				// 色
	// public ActionPattern actionPattern;	// 行動パターン？
	// public MoveType moveType = MoveType.Headlong;	// 移動パターン
}
