using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

	void OnTriggerEnter () {
		Debug.Log ("GOT");

	}
	void OnTriggerExit(Collider other){
		Debug.Log ("GOT");

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
