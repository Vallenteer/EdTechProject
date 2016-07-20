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
}
