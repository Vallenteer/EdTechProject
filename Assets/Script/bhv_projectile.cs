using UnityEngine;
using System.Collections;

public class bhv_projectile : MonoBehaviour {

	[SerializeField] int speed = 10;
	public float lifetime; //bisa dihapus, untuk menghilangkan object

	void Update () {
		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Destroy (gameObject);
		}

		this.transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime );
	}
		
}


