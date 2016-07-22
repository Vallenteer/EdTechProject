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
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));                
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
			}
		}

		if (Input.GetMouseButtonUp(0) && !cooldownState) {
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
