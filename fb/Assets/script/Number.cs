using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {

	public GameObject n0;
	public GameObject n1;
	public GameObject n2;
	public GameObject n3;
	public GameObject n4;
	public GameObject n5;
	public GameObject n6;
	public GameObject n7;
	public GameObject n8;
	public GameObject n9;
	private GameObject[] numbers;
	private int current = 0;
	// Use this for initialization
	void Awake () {
		numbers = new GameObject[]{n0, n1, n2, n3, n4, n5, n6, n7, n8, n9};
		Disable ();
	}
	public void Display (int number) {
		number = number % 10;
		if (numbers[current]) {
			numbers[current].renderer.enabled = false;
		}
		numbers[number].renderer.enabled = true;
		current = number;
		Debug.Log (number);
	}
	public void Disable () {
		foreach(GameObject n in numbers) {
			n.renderer.enabled = false;
		}
	}
}
