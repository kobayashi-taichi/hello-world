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

	void OnGUI(){
		Scene.State state = scene.GetState();
/*
		switch(state) {
		case Scene.State.TITLE:
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			GUILayout.Button("hoge", 
			if (GUILayout.Button("START")) {
				scene.EnterPlaying();
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			break;
		case Scene.State.GAMEOVER:
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			if (GUILayout.Button("RETRY")) {
				scene.EnterTitle();
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			break;

		}
*/

	}
}
