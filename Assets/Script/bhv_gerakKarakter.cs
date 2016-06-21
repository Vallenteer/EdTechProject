using UnityEngine;
using System.Collections;

public class bhv_gerakKarakter : MonoBehaviour {

	Vector2 mousePos;

	[Header("Projectile")]
	[SerializeField] GameObject projectile;
	[SerializeField] Vector3 projectileOffset;

	void Start () {
		Cursor.visible = false;
	}


	void Update () {
		//Ikutin gerak mouse
		mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		this.transform.position = (Vector3) mousePos;

		if (Input.GetMouseButtonDown(0)) {
			Tembak ();
		}
	}
		
	void Tembak() {
		Instantiate (projectile, this.transform.position + projectileOffset, projectile.transform.rotation);
	}
}
