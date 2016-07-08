using UnityEngine;
using System.Collections;

public class bhv_spawner : MonoBehaviour {

	[Header("Object to Spawn")]
	[SerializeField] GameObject[] obj;
	int arrSize;
	[SerializeField] GameObject[] obj_boss;
	int arrSizeBoss;

	[Header("Spawn Location Offset")]
	[SerializeField] Vector2 locMin;
	[SerializeField] Vector2 locMax;

	[Header("Spawn Manipulator")]
	[SerializeField] bool bossTime = false;
	public bool bossSpawned = false;
	[SerializeField] float Timer;

	void Start () {
		arrSize = obj.Length;
		arrSizeBoss = obj_boss.Length;
		StartCoroutine (Ispawn ());
	}

	IEnumerator Ispawn(){
		while (true) {
			if (!bossTime) {
				bossSpawned = false;
				spawnMusuhNormal ();
				yield return new WaitForSeconds (Timer);
			} else if (!bossSpawned) {
				spawnBoss ();
				bossSpawned = true;
			}
			yield return null;
		}
	}

	public void StartSpawn(){
		StartCoroutine (Ispawn ());
	}

	public void StopSpawn(){
		StopCoroutine (Ispawn ());
	}

	public void changeBossTimeState(){
		bossTime = !bossTime;
	}

	void spawnMusuhNormal(){
		int randomizer = Random.Range (0, arrSize-1);
		Instantiate (obj[randomizer], this.transform.position
			+ new Vector3 (Random.Range (locMin.x, locMax.x), Random.Range (locMin.y, locMax.y), 0),
			obj[randomizer].transform.rotation);
	}

	void spawnBoss(){
		int randomizer = Random.Range (0, arrSizeBoss-1);
		Instantiate (obj_boss[randomizer], this.transform.position, obj_boss[randomizer].transform.rotation);
	}
}
