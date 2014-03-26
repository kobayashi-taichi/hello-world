using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : MonoBehaviour {
	// set by inspector
	public GameObject Hud;
	public float jumpedY = 0f;
	public float maxSpeed = 3f;
	public float beginingFallOffsetY = 0.1f;
	public Vector3 velocityJump;
	public Vector3 velocityForward;
	private Scene scene;
	private GameObject playerSprite;
	private GameObject mainCamera;

	private Vector3 initial_position;
	private bool isClicked = false;
	private bool isDead = false;

	// Use this for initialization
	void Awake () {
		initial_position = transform.position;
		scene = GameObject.Find("Scene").GetComponent<Scene>();
		playerSprite = transform.FindChild("PlayerSprite").gameObject;
		mainCamera = GameObject.Find("Camera");

	}
	void OnTriggerExit2D(Collider2D other) {
		scene.Score.AddScore();
	}
	void OnCollisionEnter2D(Collision2D collision) {
		GameObject go = collision.gameObject;
		if (go.CompareTag("Roof")) {
			return;
		}
		if (go.CompareTag("Blocker")) {
			Blocker.DisableAll();
			Die ();
		}
		if (go.CompareTag("Ground")) {
			Die ();
			scene.EnterGameover();
		}
	}

	public void Init() {
		transform.position = initial_position;
		playerSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		rigidbody2D.isKinematic = true;	
		Animator animator = GetComponentInChildren<Animator>();
		if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ready")) {
			animator.SetTrigger("ready");
		}
		enabled = false;
	}
	public void Play() {
		enabled = true;
		rigidbody2D.isKinematic = false;
		GetComponentInChildren<Animator> ().SetBool ("playing", true);
		isDead = false;
		isClicked = true;
	}
	public void Die() {
		if (isDead) return;
		// stop x
		Vector3 velocity = rigidbody2D.velocity;
		velocity.x = 0;
		rigidbody2D.velocity = velocity;
		iTween.RotateTo(playerSprite, iTween.Hash(
			"z", -90, "easeType", iTween.EaseType.linear, "speed", 500f));
		iTween.ShakePosition(mainCamera, iTween.Hash(
			"time", 0.5f, "x", 0.05f, "y", 0.05f));

		GetComponentInChildren<Animator> ().SetBool ("playing", false);
		isDead = true;
		enabled = false;
	}
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			isClicked = true;
		}
	}
	void FixedUpdate () {
		Vector3 velocity = rigidbody2D.velocity;
		velocity.x = velocityForward.x;
		if (isClicked) {
			velocity.y = velocityJump.y;
			iTween.RotateTo(playerSprite, iTween.Hash(
				"z", 30, "easeType", iTween.EaseType.linear, "speed", 300f));
			jumpedY = transform.position.y;
			isClicked = false;
		}
		if (velocity.y <= 0 && ((jumpedY + 0.1 - transform.position.y) > 0)) {
			iTween.RotateTo(playerSprite, iTween.Hash(
				"z", -90, "easeType", iTween.EaseType.linear, "speed", 500f));
			jumpedY = -999f;
		}
//		rigidbody2D.velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
		rigidbody2D.velocity = velocity;
	}
}
