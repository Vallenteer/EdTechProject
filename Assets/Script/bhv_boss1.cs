﻿using UnityEngine;
using System.Collections;

public class bhv_boss1 : MonoBehaviour {

	[Header("Ref")]
	[SerializeField] GameObject manager;
	mng_soalGenerator soalManager;
	mng_playerStat statManager;

	[Header("Properties")]
	[SerializeField] int nyawaBoss = 3;
	[SerializeField] float timeBeforeRefreshMin = 10;
	[SerializeField] float timeBeforeRefreshMax = 15;
	[SerializeField] float offsetYMax = 10;
	[SerializeField] float offsetYMin = 10;
	[SerializeField] float speed = 2;
	float speedDir = -1;
	Vector3 originalPos;

	[Header("Projectile")]
	[SerializeField] GameObject projectile;
	[SerializeField] float cooldownMin = 3;
	[SerializeField] float cooldownMax = 7;
	[SerializeField] float projectileOffsetMax = 0;
	[SerializeField] float projectileOffsetMin = 0;

	[Header("Child Object Prop")]
	[SerializeField] Sprite[] arr_angka;
	[SerializeField] GameObject[] childObj;
	[SerializeField] int carriedAnswer1;
	[SerializeField] int carriedAnswer2;
	[SerializeField] int carriedAnswer3;

	void Start () {
		if (manager == null) { //Init Ref GameObject Manager
			manager = GameObject.Find ("GameManager").gameObject;
		}

		soalManager = manager.GetComponent<mng_soalGenerator> ();
		statManager = manager.GetComponent<mng_playerStat> ();
		originalPos = this.transform.position;
		RegenJawaban ();
		StartCoroutine (IBehaviorBoss());
		StartCoroutine (IBehaviorBoss2 ());
	}

	void Update() {
		if (this.transform.position.y > originalPos.y + offsetYMax || this.transform.position.y < originalPos.y - offsetYMin  ) {
			speed *= speedDir;
		}

		this.transform.Translate (new Vector3 (0, speed, 0) * Time.deltaTime);
	}

	void RegenJawaban() { //TODO : Modif agar tidak terlalu "hardcode"
		carriedAnswer1 = soalManager.generateJawaban ();
		carriedAnswer2 = soalManager.generateJawaban ();
		carriedAnswer3 = soalManager.generateJawaban ();
		childObj[0].GetComponent<bhv_hitboxBoss1>().CarriedAnswer = carriedAnswer1;
		childObj[1].GetComponent<bhv_hitboxBoss1>().CarriedAnswer = carriedAnswer2;
		childObj[2].GetComponent<bhv_hitboxBoss1>().CarriedAnswer = carriedAnswer3;
		childObj [0].GetComponent<SpriteRenderer> ().sprite = arr_angka [carriedAnswer1];
		childObj [1].GetComponent<SpriteRenderer> ().sprite = arr_angka [carriedAnswer2];
		childObj [2].GetComponent<SpriteRenderer> ().sprite = arr_angka [carriedAnswer3];
	}

	IEnumerator IBehaviorBoss(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (timeBeforeRefreshMin, timeBeforeRefreshMax));
			RegenJawaban ();
		}
	}

	IEnumerator IBehaviorBoss2(){
		while (true) {
			float posMin = this.transform.position.y - projectileOffsetMin;
			float posMax = this.transform.position.y + projectileOffsetMax;
			Instantiate (
				projectile,
				this.transform.position + new Vector3 (0, Random.Range (posMin,posMax), 0),
				projectile.transform.rotation);
			yield return new WaitForSeconds (Random.Range (cooldownMin, cooldownMax));
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			statManager.kurangNyawa();
		}
	}

	void HitBoxHit(int carriedAnswer){
		if (soalManager.angkaJawab == carriedAnswer) {
			statManager.tambahScore ();
			soalManager.callBuatSoal ();
			nyawaBoss--;
			RegenJawaban ();
		} else {
			statManager.kurangScore ();
			soalManager.callBuatSoal ();
			RegenJawaban ();
		}
	}
}