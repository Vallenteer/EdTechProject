﻿using UnityEngine;
using System.Collections;

public class bhv_musuh : MonoBehaviour {

	//TODO : Buat child object buat nunjukkin angka yang dibawa musuh


	[Header("Ref")]
	[SerializeField] GameObject manager;
	mng_soalGenerator soalManager;
	mng_playerStat statManager;

	[Header("Properties")]
	[SerializeField] float speed = 5;
	[SerializeField] int carriedAnswer;

	void Start(){
		if (manager == null) { //Init Ref GameObject Manager
			manager = GameObject.Find ("GameManager").gameObject;
		}

		soalManager = manager.GetComponent<mng_soalGenerator> ();
		statManager = manager.GetComponent<mng_playerStat> ();
		carriedAnswer = soalManager.generateJawaban ();
	}

	void Update () {
		this.transform.Translate (new Vector3 (-speed, 0, 0) * Time.deltaTime );
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			statManager.kurangNyawa();
			Destroy (this.gameObject);
		}

		if (other.gameObject.CompareTag ("Projectile")) {
			if (soalManager.angkaJawab == carriedAnswer) {
				statManager.tambahScore ();
				soalManager.callBuatSoal ();
				Destroy (this.gameObject);
			} else {
				statManager.kurangScore ();
				soalManager.callBuatSoal ();
				Destroy (this.gameObject); //TODO : hapus baris ini, kalo pas salah, musuhnya tetep ada
			}
		}

	}
}