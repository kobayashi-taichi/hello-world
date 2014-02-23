using UnityEngine;
using System.Collections;

public class PlayerTracer : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			player.transform.position.x + offset.x,
			transform.position.y,
			player.transform.position.z + offset.z
		);
	}
}
