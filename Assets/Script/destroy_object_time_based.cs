using UnityEngine;
using System.Collections;

public class destroy_object_time_based : MonoBehaviour {

	[SerializeField] float lifetime; //bisa dihapus, untuk menghilangkan object
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Destroy (gameObject);
		}

	}
}
