using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_playerStat : MonoBehaviour {

	[Header("Ref")]
	[SerializeField] GameObject spawner;
	bhv_spawner spawnerScript;

	[Header("Game Status")]
	[SerializeField] int nyawa = 3;
	[SerializeField] int score;

	[Header("Trigger Prop")]
	[SerializeField] int scoreTreshold = 100; //Pas dapet berapa si boss bakal ke trigger
	[SerializeField] int scoreScaling = 200; //treshold nambah berapa abis bossnya mati

	[Header("UI Text Object")]
	[SerializeField] Text ui_textNyawa;
	[SerializeField] Text ui_textScore;
	[SerializeField] Text ui_textNyawaBoss;

	void Start () {
		ui_textNyawa.text = nyawa.ToString ();
		ui_textScore.text = score.ToString ();
		ui_textNyawaBoss.gameObject.SetActive(false);

		spawnerScript = spawner.GetComponent<bhv_spawner> ();
	}

	void Update(){
		if (!spawnerScript.bossSpawned && score >= scoreTreshold) {
			spawnerScript.changeBossTimeState ();
			scoreTreshold += scoreScaling;
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
		ui_textNyawaBoss.gameObject.SetActive (act);
	}

	public void refreshUInyawaBoss(int n){
		ui_textNyawaBoss.text = n.ToString();
	}

}
