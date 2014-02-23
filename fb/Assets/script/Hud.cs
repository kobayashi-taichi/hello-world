using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	private Scene scene;

	void OnGUI(){
		if (!scene) {
			scene = GameObject.Find("Scene").GetComponent<Scene>();
		}
		Scene.State state = scene.GetState();
		switch(state) {
		case Scene.State.TITLE:
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

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
	}
}
