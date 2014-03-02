using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GameObject ScoreText;
	public GameObject HighScoreText;
	private int highScore = 0;
 	private int score = 0;
	private int max = 9999;
	public void AddScore() {
		SetScore (score + 1);
	}
	public void SetScore(int score) {
		this.score = score;
	}
	// Update is called once per frame
	void Update () {
		if (score > max) return;
		string _score = string.Format("{0:D4}", score);
		ScoreText.guiText.text = _score; 
		if (score > highScore) {
			highScore = score;
			HighScoreText.guiText.text = _score;
		}
	
	}
}
