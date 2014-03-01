using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	private Scene scene;
	private GameObject startButton;
	private GameObject gameoverButton;
	void Awake () {
		scene = GameObject.Find("Scene").GetComponent<Scene>();
		startButton = transform.FindChild("StartButton").gameObject;
		startButton.renderer.enabled = false;
		gameoverButton = transform.FindChild("GameoverButton").gameObject;
		gameoverButton.renderer.enabled = false;
	}
	void Update() {
		Scene.State state = scene.GetState();
		switch(state) {
		case Scene.State.TITLE:
			startButton.renderer.enabled = true;
			gameoverButton.renderer.enabled = false;
			if (Input.GetMouseButtonDown(0)) {
				scene.EnterPlaying();
			}
			break;
		case Scene.State.GAMEOVER:
			gameoverButton.renderer.enabled = true;
			if (Input.GetMouseButtonDown(0)) {
				scene.EnterTitle();
			}
			break;
		default:
			startButton.renderer.enabled = false;
			gameoverButton.renderer.enabled = false;
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
