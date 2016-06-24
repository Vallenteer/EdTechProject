using UnityEngine;
using System.Collections;

public class bhv_spawner : MonoBehaviour {

	[Header("Object to Spawn")]
	[SerializeField] GameObject obj;

	[Header("Spawn Location Offset")]
	[SerializeField] Vector2 locMin;
	[SerializeField] Vector2 LocMax;

	[Header("Spawn Manipulator")]
	[SerializeField] float Timer;

	void Start () {
		StartCoroutine (Ispawn ());
	}

	IEnumerator Ispawn(){
		while (true) {
			Instantiate (obj, this.transform.position
			+ new Vector3 (Random.Range (locMin.x, LocMax.x), Random.Range (locMin.y, LocMax.y), 0),
				obj.transform.rotation);
			yield return new WaitForSeconds (Timer);
		}
	}

	public void StartSpawn(){
		StartCoroutine (Ispawn ());
	}

	public void StopSpawn(){
		StopCoroutine (Ispawn ());
	}
}
