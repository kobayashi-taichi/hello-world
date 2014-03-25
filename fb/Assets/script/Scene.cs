using UnityEngine;
using System.Collections;

delegate void UpdateState();

public class Scene : MonoBehaviour {
	public enum State {
		TITLE, READY, PLAYING, GAMEOVER
	}
	public GameObject Hud;
	public Score Score;
	private State state;
	private Player player;
	private Spawner spawner;

	void Awake () {
		player = GameObject.Find("Player").GetComponent<Player>();
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
		Score = Hud.GetComponent<Score>();
	}
	void Start () {
		EnterTitle();
	}
	public void EnterTitle() {
		state = State.TITLE;
		player.Init ();
		Blocker.RemoveAll();
		spawner.Reset();
		Score.SetScore(0);
	}
	public void EnterPlaying() {
		player.Play();
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
}
