using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_gameOverBhv : MonoBehaviour {

	mng_sceneManager sceneScript;

	void Start () {
		sceneScript = GameObject.Find ("SceneManager").GetComponent<mng_sceneManager> ();
		GameObject.Find ("FinalScore").transform.Find("Text").GetComponent<Text> ().text = sceneScript.passed_score.ToString();
	}

	public void backToMenu(){
		sceneScript.loadMenuScene ();
	}
}
