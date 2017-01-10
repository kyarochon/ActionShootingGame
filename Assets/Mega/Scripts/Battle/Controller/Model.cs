using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Model : MonoBehaviour {
		// アニメーション用
		protected Animator myAnimator;

		// 点滅用
		public GameObject body;
		public GameObject rightEye;
		public GameObject leftEye;
		public GameObject rightEyeBrow;
		public GameObject leftEyeBrow;

		void Awake () {
			myAnimator = this.GetComponent<Animator> ();
		}

		void Update () {

		}

		// アニメーション用
		public void setIsJump(bool isJump)
		{
			this.myAnimator.SetBool ("Jump", isJump);
		}
		public void setSpeed(float speed)
		{
			this.myAnimator.SetFloat ("Speed", speed);
		}

		// 点滅用
		public void setIsVisible(bool isVisible)
		{
			float alpha = (isVisible) ? 1.0f : 0.0f;
			this.setAlpha (body.GetComponent<SkinnedMeshRenderer> ().material,  alpha);
			this.setAlpha (rightEye.GetComponent<MeshRenderer> ().material,     alpha);
			this.setAlpha (leftEye.GetComponent<MeshRenderer> ().material,      alpha);
			this.setAlpha (rightEyeBrow.GetComponent<MeshRenderer> ().material, alpha);
			this.setAlpha (leftEyeBrow.GetComponent<MeshRenderer> ().material,  alpha);
		}

		private void setAlpha(Material material, float alpha)
		{
			Color color = material. GetColor ("_Color" );
			color.a = alpha;
			material.SetColor ("_Color", color);
		}

	}
}