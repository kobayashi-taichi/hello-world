using UnityEngine;
using System.Collections;

public class PlayerTracer : MonoBehaviour {

	public float smoothX = 15f;
	public GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = new Vector3(
//			Mathf.Lerp (transform.position.x, player.transform.position.x + offset.x, Time.deltaTime * smoothX),
//			transform.position.y,
//			player.transform.position.z + offset.z
//		);
		transform.position = new Vector3(
			player.transform.position.x + offset.x,
			transform.position.y,
			player.transform.position.z + offset.z
		);
	}
}
