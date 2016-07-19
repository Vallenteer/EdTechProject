using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//BGM
	[SerializeField] GameObject BGM;
	// Use this for initialization
	void Start () {
		// Set camera aspect ratio
		Camera.main.aspect = 16f/9f;
		if (!GameObject.FindGameObjectWithTag ("BGM")) {
			DontDestroyOnLoad (Instantiate (BGM));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
