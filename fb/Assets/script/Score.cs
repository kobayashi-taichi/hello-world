using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GameObject Numbers;
	private GameObject[] numbers = new GameObject[10];
	private int score = 0;
	public void AddScore() {
		SetScore (score + 1);
	}
	public void SetScore(int score) {
		this.score = score;
		string str = score.ToString();
		for (int i = 0; i < 10; i++) {
			Number n = numbers[i].GetComponent<Number>();
			int len = str.Length;
			if (i < len) {
				n.Display(int.Parse(str[len - i - 1].ToString()));
			} else {
				n.Disable();
			}

		}
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			numbers[i] = (GameObject)Instantiate(Numbers);
			numbers[i].transform.position = new Vector3(-0.12f * i, transform.position.y, transform.position.z);
			numbers[i].transform.parent = transform;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
