using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject BlockerPrefab;

	public float MAX_Y;
	public float MIN_Y;
	public float INTERVAL;
	float lastX = 0;

	GameObject player;
	Scene scene;
	void Awake () {
		player = GameObject.Find("Player");
		scene = GameObject.Find ("Scene").GetComponent<Scene>();
	}
	// Use this for initialization
	void Start () {
		Reset ();
	}
	public void Reset () {
		lastX = player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!scene.isState(Scene.State.PLAYING)) {
			return;
		}
		float deltaDist = player.transform.position.x - lastX;
		if (deltaDist < INTERVAL) {
			return;
		}
		Spawn ();
		Reset ();
	}
	void Spawn () {
		Vector3 newPosition = new Vector3(player.transform.position.x, 0, 0);
		GameObject go = (GameObject)Instantiate(BlockerPrefab);
		newPosition.x += 2;
		newPosition.y = Random.Range(MIN_Y, MAX_Y);
		go.transform.position = newPosition;
	}
}
