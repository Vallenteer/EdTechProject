using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_playerStat : MonoBehaviour {

	[Header("Ref")]
	[SerializeField] GameObject spawner;
	[SerializeField] GameObject sceneManager;
	bhv_spawner spawnerScript;
	public mng_sceneManager sceneScript;

	[Header("Game Status")]
	[SerializeField] int nyawa = 3;
	[SerializeField] int score;

	[Header("Trigger Prop")]
	[SerializeField] bool endlessMode = false;
	[SerializeField] int scoreTreshold = 100; //Pas dapet berapa si boss bakal ke trigger
	[SerializeField] int scoreScaling = 200; //treshold nambah berapa abis bossnya mati (ga terlalu dipake kalau bukan endless mode)

	[Header("UI Text Object")]
	[SerializeField] Text ui_textNyawa;
	[SerializeField] Text ui_textScore;
	[SerializeField] GameObject textNyawaBoss;
	[SerializeField] Text ui_textNyawaBoss;

	[Header("Scene Tracker")]
	[SerializeField] int levelKe = 1; //level ke-
	[SerializeField] int nextLevelToLoad = 2;

	void Awake(){
		sceneManager = GameObject.Find ("SceneManager");
		sceneScript = sceneManager.GetComponent<mng_sceneManager> ();
	}

	void Start () {
		if (levelKe != 1) {
			score = sceneScript.passed_score;
		} else {
			score = 0;
		}
		ui_textNyawa.text = nyawa.ToString ();
		ui_textScore.text = score.ToString ();
		textNyawaBoss.gameObject.SetActive(false);
		ui_textNyawaBoss = textNyawaBoss.transform.Find ("ui_NyawaBoss").gameObject.GetComponent<Text> ();


		spawnerScript = spawner.GetComponent<bhv_spawner> ();
	}

	void Update(){
		if (!spawnerScript.bossSpawned && score >= scoreTreshold) {
			spawnerScript.changeBossTimeState ();
			scoreTreshold += scoreScaling;
		}

		if (nyawa <= 0) {
			Debug.Log ("GameOver");
			sceneScript.passed_score = score;
			sceneScript.loadGameOver (); //pas mati
		}
	}
		
	public void tambahNyawa(int jumlah = 1){
		nyawa += jumlah;
		ui_textNyawa.text = nyawa.ToString ();
	}

	public void kurangNyawa(int jumlah = 1){
		nyawa -= jumlah;
		ui_textNyawa.text = nyawa.ToString ();
	}

	public void tambahScore(int jumlah = 1){
		score += jumlah;
		ui_textScore.text = score.ToString ();
	}

	public void kurangScore(int jumlah = 1){
		score -= jumlah;
		ui_textScore.text = score.ToString ();
	}

	public void enableUInyawaBoss(bool act){
		textNyawaBoss.gameObject.SetActive (act);
	}

	public void refreshUInyawaBoss(int n){
		ui_textNyawaBoss.text = n.ToString();
	}

	public int getLevelKe(){
		return levelKe;
	}

	public void loadNextLevel(){
		if (endlessMode && levelKe < 3) {
			levelKe++;
			nextLevelToLoad++;
		} else {
			sceneScript.passed_score = score; //pass score
			sceneScript.LoadedLevel=levelKe;
			sceneScript.loadNextLevel (nextLevelToLoad);
		}
	}
		
}
