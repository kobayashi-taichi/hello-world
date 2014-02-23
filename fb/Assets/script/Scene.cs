using UnityEngine;
using System.Collections;

delegate void UpdateState();

public class Scene : MonoBehaviour {
	public enum State {
		TITLE, READY, PLAYING, GAMEOVER
	}
	private State state;
	private Score score;

	// Use this for initialization
	void Start () {
		EnterTitle();
	}
	public void EnterTitle() {
		state = State.TITLE;
		Player player = GameObject.Find("Player").GetComponent<Player>();
		player.ChangePlayerState(Player.PlayerState.IDLE);
		Blocker.RemoveAll();
		Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
		spawner.Reset();
		Score score = GameObject.Find("Score").GetComponent<Score>();
		score.SetScore(0);
	}
	public void EnterPlaying() {
		state = State.PLAYING;
	}
	public void EnterGameover() {
		state = State.GAMEOVER;
	}
	public State GetState(){
		return state;
	}
	public bool isState(State state){
		return this.state == state;
	}

	// Update is called once per frame
	void Update () {
	}
}
