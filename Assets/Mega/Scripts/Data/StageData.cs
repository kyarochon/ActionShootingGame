using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject {
	// シーンファイル名
	public string sceneName = "";

	// 主人公の出現位置
	public Vector3 heroPos = new Vector3 (0.0f, 0.0f, 0.0f);
}
