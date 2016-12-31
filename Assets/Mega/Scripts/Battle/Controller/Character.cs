﻿using UnityEngine;
using System.Collections;

namespace Mega.Battle.Controller {

	public class Character : MonoBehaviour {
		public GameObject bulletPrefab;

		protected Direction2D moveDirection = Direction2D.None;
		protected Direction2D faceDirection = Direction2D.Right;

		protected bool commandJump;
		protected bool commandBullet;
		protected bool isGround;

		protected Info.Character characterInfo;
		protected Rigidbody myRigidbody;
		protected Animator myAnimator;

		// Use this for initialization
		virtual protected void Start () {
			myRigidbody = this.GetComponent<Rigidbody> ();
			myAnimator = this.transform.FindChild ("model").gameObject.GetComponent<Animator> ();

			commandJump = false;
			isGround = true;
		}

		// Update is called once per frame
		virtual protected void Update () {
			// 移動
			this.move ();

			// ジャンプ
			if (commandJump && isGround) {
				this.myRigidbody.AddForce (this.transform.up * this.characterInfo.getUpForce ());
			}


			// 弾を打つ
			if (commandBullet) {
				GameObject bullet = Instantiate (bulletPrefab) as GameObject;
				Bullet bulletScript = bullet.GetComponent<Bullet> ();
				bulletScript.init (faceDirection, this.transform.position);
			}

			// アニメーション遷移
			this.myAnimator.SetBool ("Jump", !isGround);
			this.myAnimator.SetFloat ("Speed", this.myRigidbody.velocity.magnitude);
		}

		protected void move()
		{
			// 移動
			switch (moveDirection) {

				// 停止
				case Direction2D.None:
				{
					break;
				}

				// 移動(右)
				case Direction2D.Right:
				{
					this.myRigidbody.AddForce (0, 0, this.characterInfo.getTurnForce (), ForceMode.Acceleration);
					this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
					this.faceDirection = Direction2D.Right;
					break;
				}

				// 移動(左)
				case Direction2D.Left:
				{
					this.myRigidbody.AddForce (0, 0, -this.characterInfo.getTurnForce (), ForceMode.Acceleration);
					this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
					this.faceDirection = Direction2D.Left;
					break;
				}
			}

			Vector3 velocity = this.myRigidbody.velocity;
			if (Mathf.Abs(velocity.z) > this.characterInfo.getMaxSpeed ()) {
				if (velocity.z > 0) {
					velocity.z = this.characterInfo.getMaxSpeed ();
				} else {
					velocity.z = -this.characterInfo.getMaxSpeed ();
				}
				this.myRigidbody.velocity = velocity;
			}

/*
			Vector3 velocity = this.myRigidbody.velocity;
			velocity.y = 0.0f;
			if (velocity.magnitude > maxSpeed)
			{
				myRigidbody.velocity = Vector3.ClampMagnitude (myRigidbody.velocity, maxSpeed);
			}
			*/
		}


		virtual public void damaged(int damage)
		{
			this.characterInfo.damaged (damage);
		}


		// Collision
		void OnCollisionEnter(Collision col)
		{
			if (col.gameObject.tag == "MoveStage") {
				transform.SetParent (col.transform);
			}
		}

		void OnCollisionExit(Collision col) {
			if (col.gameObject.tag == "MoveStage") {
				transform.SetParent (null);
			}
		}

		// Trigger
		void OnTriggerEnter()
		{
			isGround = true;
		}

		void OnTriggerStay(Collider collider)
		{
			isGround = true;
		}

		void OnTriggerExit()
		{
			isGround = false;
		}

	}
}
