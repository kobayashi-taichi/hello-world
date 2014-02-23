using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {
	public static void RemoveAll() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Blocker");
		foreach (GameObject go in gos) {
			Destroy (go);
		}
	}

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	void OnBecameInvisible () {
		Destroy(this.gameObject);
	}
}
