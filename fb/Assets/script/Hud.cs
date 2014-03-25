using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	private Scene scene;
	public GameObject startButton;
	public GameObject gameoverButton;
	void Awake () {
		scene = GameObject.Find("Scene").GetComponent<Scene>();
	}
	void Start () {
		startButton.guiText.enabled = false;
		gameoverButton.guiText.enabled = false;
	}
	void Update() {
		Scene.State state = scene.GetState();
		switch(state) {
		case Scene.State.TITLE:
			startButton.guiText.enabled = true;
			gameoverButton.guiText.enabled = false;
			if (Input.GetMouseButtonDown(0)) {
				scene.EnterPlaying();
			}
			break;
		case Scene.State.GAMEOVER:
			gameoverButton.guiText.enabled = true;
			if (Input.GetMouseButtonDown(0)) {
				scene.EnterTitle();
			}
			break;
		default:
			startButton.guiText.enabled = false;
			gameoverButton.guiText.enabled = false;
			break;
		}
	}
}
