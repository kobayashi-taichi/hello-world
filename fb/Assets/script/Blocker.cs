using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {
	public static void RemoveAll() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Blocker");
		foreach (GameObject go in gos) {
			Destroy (go);
		}
	}
	public static void DisableAll() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Blocker");
		foreach (GameObject go in gos) {
			BoxCollider2D[] bc2s = go.GetComponents<BoxCollider2D>();
			foreach(BoxCollider2D bc2 in bc2s) {
				bc2.enabled = false;
			}
		}
	}
	void OnBecameInvisible () {
		Destroy(this.gameObject, 1f);
	}
}
