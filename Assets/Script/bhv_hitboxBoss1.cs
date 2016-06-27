using UnityEngine;
using System.Collections;

public class bhv_hitboxBoss1 : MonoBehaviour {

	[Header("Properties")]
	[SerializeField] public int CarriedAnswer;

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Projectile")) {
			SendMessageUpwards ("HitBoxHit", CarriedAnswer);
			Destroy (other.gameObject);
		}
	}
}
