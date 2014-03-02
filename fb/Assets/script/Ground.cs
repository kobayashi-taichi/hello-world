﻿using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public GameObject camera;
	private Vector3 initial_position;
	private float width = 1.27f;
	private static int NUM = 4;

	// Use this for initialization
	void Start () {
		initial_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float  total_width = width * NUM;
		float dist = camera.transform.position.x - initial_position.x;
		int n = Mathf.RoundToInt(dist / total_width);
		Vector3 position = initial_position;
		position.x += n * total_width;
		transform.position = position;
	}
}
