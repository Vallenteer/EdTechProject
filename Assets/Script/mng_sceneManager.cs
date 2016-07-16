using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mng_sceneManager : MonoBehaviour {

	[Header("Scene List")]
	[SerializeField] Object menuScene;
	[SerializeField] Object GameOverScene;
	[SerializeField] Object FinalScoreScene;
	[SerializeField] Object[] LevelScene; //urut 1-3
	[SerializeField] Object[] StoryScene; //Opsional

	[Header("Passed Value")]
	public int passed_score;

	static bool exist = false;

	void Awake(){
		if (!exist) {
			DontDestroyOnLoad (this.gameObject);
			exist = true;
		} else {
			Destroy (this.gameObject);
		}
	}

	public void loadNextLevel(int n){
		SceneManager.LoadScene (LevelScene [n - 1].name);
	}

	public void loadGameOver(){
		SceneManager.LoadScene (GameOverScene.name);
	}

	public void loadStoryScene(int n){
		SceneManager.LoadScene (StoryScene [n - 1].name);
	}

	public void loadFinalScoreScene(){
		SceneManager.LoadScene (FinalScoreScene.name);
	}

	public void loadMenuScene(){
		SceneManager.LoadScene (menuScene.name);
	}

	public void changePauseState(bool state){ //opsional kalau mau pause game
		if (state) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void exitApp(){
		Application.Quit();
	}
}
