using UnityEngine;
using System.Collections;

public class bhv_musuh : MonoBehaviour {

	[Header("Ref")]
	[SerializeField] GameObject hitbyprojectile;
	[SerializeField] GameObject playerhit;
	[SerializeField] GameObject manager;
	mng_soalGenerator soalManager;
	mng_playerStat statManager;

	[Header("Properties")]
	[SerializeField] float speed = 5;
	[SerializeField] int carriedAnswer;

	[Header("Child Object Prop")]
	[SerializeField] Sprite[] arr_angka;

	void Start(){
		if (manager == null) { //Init Ref GameObject Manager
			manager = GameObject.Find ("GameManager").gameObject;
		}

		soalManager = manager.GetComponent<mng_soalGenerator> ();
		statManager = manager.GetComponent<mng_playerStat> ();
		carriedAnswer = soalManager.generateJawaban ();
		this.gameObject.transform.FindChild("obj_CarrierAngka").GetComponent<SpriteRenderer>().sprite = arr_angka [carriedAnswer];
	}

	void Update () {
		this.transform.Translate (new Vector3 (-speed, 0, 0) * Time.deltaTime );
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			statManager.kurangNyawa();
			Instantiate (playerhit);
			Destroy (this.gameObject);
		}

		if (other.gameObject.CompareTag ("Projectile")) {
			if (soalManager.angkaJawab == carriedAnswer) {
				statManager.tambahScore ();
				soalManager.callBuatSoal ();
				Destroy (other.gameObject);
				Destroy (this.gameObject);
			} else {
				statManager.kurangScore ();
				soalManager.callBuatSoal ();
				Destroy (other.gameObject);
				Destroy (this.gameObject); //TODO : hapus baris ini, kalo pas salah, musuhnya tetep ada
			}
			Instantiate (hitbyprojectile);
		}

	}
}
