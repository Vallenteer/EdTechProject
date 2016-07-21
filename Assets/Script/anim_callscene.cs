using UnityEngine;
using System.Collections;

public class anim_callscene : MonoBehaviour {
	public mng_sceneManager sceneManager;
	[SerializeField] GameObject canvas;
	// Use this for initialization
	void Start () {
		sceneManager =GameObject.Find("SceneManager").GetComponent<mng_sceneManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callMng_Scene(int param){
		sceneManager.loadNextLevel (param);
	}
	public void hidecanvas ()
	{
		canvas.SetActive (false);
	}

	public void transisi(){
		switch (sceneManager.LoadedLevel) {
		case 1:
			sceneManager.loadNextLevel (2);
			break;
		case 2:
			sceneManager.loadNextLevel (3);
			break;
		case 3:
			sceneManager.loadNextLevel (6);
			break;
		}
	}
}
