using UnityEngine;
using System.Collections;

public class bhv_projectile : MonoBehaviour {

	[SerializeField] int speed = 10;

	void Update () {
		this.transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime );
	}
		
}
