using UnityEngine;
using System.Collections;

public class bhv_gerakKarakter : MonoBehaviour {

	Vector2 mousePos;

	void Start () {
	}

	void Update () {
		//Ikutin gerak mouse
		mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		this.transform.position = (Vector3) mousePos;
	}
}
