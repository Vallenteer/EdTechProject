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
	[SerializeField] public int LoadedLevel = 0;

	static bool exist = false;

	void Awake(){
		if (!exist) {
			DontDestroyOnLoad (this.gameObject);
			exist = true;
		} else {
			Destroy (this.gameObject);
		}
	}

	void Start(){
		//Camera.main.aspect = 16f/9f;
	}

	//TODO : Rubah metode load scene, kalau terpaksa pakai build index num

	public void loadNextLevel(int n){
		//SceneManager.LoadScene (LevelScene [n - 1].name);

		SceneManager.LoadScene (n);
	}

	public void loadGameOver(){
		//SceneManager.LoadScene (GameOverScene.name);
		LoadedLevel = 4;
		SceneManager.LoadScene (4);
	}

	public void loadStoryScene(int n){
		//SceneManager.LoadScene (StoryScene [n - 1].name);

		SceneManager.LoadScene (n);
	}

	public void loadFinalScoreScene(){
		//SceneManager.LoadScene (FinalScoreScene.name);
		LoadedLevel = 4;
		SceneManager.LoadScene (4);
	}

	public void loadMenuScene(){
		//SceneManager.LoadScene (menuScene.name);
		LoadedLevel = 0;
		SceneManager.LoadScene (0);
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
