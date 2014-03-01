using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {
	public static void RemoveAll() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Blocker");
		foreach (GameObject go in gos) {
			Destroy (go);
		}
	}
	void OnBecameInvisible () {
		Destroy(this.gameObject, 1f);
	}
}
