using UnityEngine;
using System.Collections;

public class bhv_gerakKarakter : MonoBehaviour {

	Vector2 mousePos;

	[Header("Projectile")]
	[SerializeField] GameObject projectile;
	[SerializeField] GameObject cooldownText;
	[SerializeField] Sprite[] cooldownSprite;
	[SerializeField] Vector3 projectileOffset;
	[SerializeField] int cooldownTime = 2;
	[SerializeField] bool cooldownState; //True for in cooldown

	void Start(){
		cooldownText.SetActive (false);
	}

	void FixedUpdate () {
		//Ikutin gerak mouse
		mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		this.transform.position = (Vector3) mousePos;

		if (Input.GetMouseButtonDown(0) && !cooldownState) {
			Tembak ();
		}
	}
		
	void Tembak() {
		Instantiate (projectile, this.transform.position + projectileOffset, projectile.transform.rotation);
		cooldownState = true;
		StartCoroutine (coolDownProjectile ());
	}

	IEnumerator coolDownProjectile(){
		cooldownText.SetActive (true);
		for (int waitTime = cooldownTime; waitTime > 0; waitTime--) {
			cooldownText.GetComponent<SpriteRenderer> ().sprite = cooldownSprite [waitTime];
			yield return new WaitForSeconds(1f);
		}
		cooldownText.SetActive (false);
		cooldownState = false;

	}
}
