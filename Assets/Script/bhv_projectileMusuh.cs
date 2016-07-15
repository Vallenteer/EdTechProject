using UnityEngine;
using System.Collections;

public class bhv_projectileMusuh : MonoBehaviour {

	[Header("Ref")]
	[SerializeField] GameObject manager;
	[SerializeField] GameObject playerhit;
	mng_playerStat statManager;

	void Start(){
		if (manager == null) {
			manager = GameObject.Find ("GameManager");
		}

		statManager = manager.GetComponent<mng_playerStat> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			statManager.kurangNyawa ();
			Instantiate (playerhit);
			Destroy (this.gameObject);
		}

		if(other.CompareTag("Destroyer")){
			Destroy(this.gameObject);
		}
	}
}
