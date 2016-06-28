using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_playerStat : MonoBehaviour {

	[Header("Game Status")]
	[SerializeField] int nyawa = 3;
	[SerializeField] int score;

	[Header("UI Text Object")]
	[SerializeField] Text ui_textNyawa;
	[SerializeField] Text ui_textScore;
	[SerializeField] Text ui_textNyawaBoss;

	void Start () {
		ui_textNyawa.text = nyawa.ToString ();
		ui_textScore.text = score.ToString ();
		ui_textNyawaBoss.gameObject.SetActive(false);
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
