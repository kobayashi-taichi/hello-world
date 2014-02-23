﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : MonoBehaviour {
	// set by inspector
	public float VX = 1;
	public float VY = 3;
	private bool isGrounded = false;
	public float flappedY = 0f;
	public float maxAngle = 30f;
	public float minAngle = -90f;
	public enum PlayerState {
		IDLE, PLAYING, DEAD
	};
	private PlayerState playerState = PlayerState.IDLE;
	private bool isFalling = false;
	private Scene scene;
	private Score score;
	private GameObject playerSprite;

	private Vector3 initial_position;
	private float target_angle;

	// Use this for initialization
	void Awake () {
		initial_position = transform.position;
	}
	void Start () {
		score = GameObject.Find("Score").GetComponent<Score>();
		playerSprite = transform.FindChild("PlayerSprite").gameObject;
		ChangePlayerState(PlayerState.IDLE);
	}
	void OnTriggerExit2D(Collider2D other) {
		score.AddScore();
	}
	void OnCollisionEnter2D(Collision2D collision) {
		GameObject go = collision.gameObject;
		if (go.CompareTag("Roof")) {
			return;
		}
		if (go.CompareTag("Blocker")) {
			BoxCollider2D[] bc2s = go.GetComponents<BoxCollider2D>();
			foreach(BoxCollider2D bc2 in bc2s) {
				bc2.enabled = false;
			}

		}
		isGrounded = true;
	}
	public void ChangePlayerState(PlayerState state) {
//		Debug.Log (state);
		// rotation speed : time = distance / speed
		Debug.Log (state);
		switch(state) {
		case PlayerState.PLAYING:
			rigidbody2D.isKinematic = false;
			GetComponentInChildren<Animator> ().SetBool ("playing", true);
			break;
		case PlayerState.IDLE:
			transform.position = initial_position;
			playerSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			rigidbody2D.isKinematic = true;	
			isGrounded = false;
			Animator animator = GetComponentInChildren<Animator>();
			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ready")) {
				animator.SetTrigger("ready");
			}
			break;
		case PlayerState.DEAD:
			GetComponentInChildren<Animator> ().SetBool ("playing", false);
			break;
		default:
			break;
		}
		playerState = state;
//			iTween.RotateTo(gameObject, iTween.Hash(
//				"z", 30, "easeType", iTween.EaseType.linear, "speed", 500f));
//			iTween.RotateTo(gameObject, iTween.Hash(
//				"z", -90, "easeType", iTween.EaseType.linear, "speed", 500f));
	}

	// Update is called once per frame
	void Update () {
		if (!scene) {
			scene = GameObject.Find("Scene").GetComponent<Scene>();
		}
		switch (playerState) {
		case PlayerState.DEAD:
			UpdateDead();
			break;
		case PlayerState.PLAYING:
			UpdatePlaying();
			break;
		case PlayerState.IDLE:
			UpdateIdle();
			break;
		}
	}
	private void UpdateIdle() {
		bool isClicked = false;
		if (!scene.isState (Scene.State.PLAYING)) {
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			isClicked = true;
		}
		if (isClicked) {
			ChangePlayerState(PlayerState.PLAYING);
			Flap();
			return;
		}
	}
	private void UpdatePlaying() {
		if (isGrounded) {
			ChangePlayerState(PlayerState.DEAD);
			scene.EnterGameover();
			return;
		}
		bool isClicked = false;
		if (Input.GetMouseButtonDown(0)) {
			isClicked = true;
		}
		transform.Translate(Vector3.right * Time.deltaTime * VX);
		if (isClicked) {
			Flap ();
		}
		UpdateRotate();

	}
	private void UpdateDead() {
	}
	private void Flap() {
		rigidbody2D.velocity = new Vector2(0, VY);
		flappedY = transform.position.y;
		target_angle = 30;
			iTween.RotateTo(playerSprite, iTween.Hash(
				"z", 30, "easeType", iTween.EaseType.linear, "speed", 500f));
		isFalling = false;
	}
	void UpdateRotate () {
		float dy = transform.position.y - flappedY;
		if (rigidbody2D.velocity.y < 0 && dy <= 0.2 && !isFalling) {
			iTween.RotateTo(playerSprite, iTween.Hash(
				"z", -100, "easeType", iTween.EaseType.linear, "speed", 500f));
			isFalling = true;
		}
	}
}
