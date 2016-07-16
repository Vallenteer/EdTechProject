using UnityEngine;
using System.Collections;

public class bhv_hitboxBoss1 : MonoBehaviour {

	[Header("Properties")]
	[SerializeField] public int CarriedAnswer;
	Sprite[] arr_angka;

	void Start(){
		refreshAngka ();
	}

	public void refreshAngka(){
		arr_angka = GetComponentInParent<bhv_boss1> ().arr_angka;
		int carriedAnswer1 = CarriedAnswer / 10;
		int carriedAnswer2 = CarriedAnswer - (carriedAnswer1 * 10);
		this.gameObject.transform.FindChild ("obj_CarrierAngka1").GetComponent<SpriteRenderer> ().sprite = arr_angka [carriedAnswer1];
		this.gameObject.transform.FindChild ("obj_CarrierAngka2").GetComponent<SpriteRenderer>().sprite = arr_angka [carriedAnswer2];
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Projectile")) {
			SendMessageUpwards ("HitBoxHit", CarriedAnswer);
			Destroy (other.gameObject);
		}
	}
}
