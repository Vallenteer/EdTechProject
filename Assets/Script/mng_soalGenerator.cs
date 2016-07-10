using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_soalGenerator : MonoBehaviour {

	[Header("Ref")]
	mng_playerStat statScript;

	[Header("UI Text Object")]
	[SerializeField] Text ui_text;

	[Header("Properties")]
	[SerializeField] int maxRandNum = 3; //kalau 1 (tambah kurang), 2 (tambah kurang kali), 3 (tambah kurang kali bagi)
	[SerializeField] int angka1;
	[SerializeField] int angka2;
	[SerializeField] public int angkaJawab;
	[SerializeField] int operatorRand;

	[Header("Manipulator")]
	[SerializeField] int fixedAnsWhen = 4;
	int ansLeftTillFixed;

	void Start () {
		statScript = this.GetComponent<mng_playerStat> ();
		switch (statScript.getSceneKe ()) {
		case 1:
			maxRandNum = 1;
			break;
		case 2:
			maxRandNum = 2;
			break;
		case 3:
			maxRandNum = 3;
			break;
		default :
			Debug.Log ("Scene Num Error");
			maxRandNum = 0;
			break;
		}
		ansLeftTillFixed = fixedAnsWhen;
		StartCoroutine (IbuatSoal ());
	}
		
	IEnumerator IbuatSoal(){
		ui_text.text = "Loading..."; //Placeholder pas lagi random soal
		string operatorRandStr;

		while (true) {
			operatorRand = Random.Range (0,maxRandNum);
			angka1 = Random.Range (0, 9);
			angka2 = Random.Range (0, 9);

			switch (operatorRand) {
			case 0:
				operatorRandStr = "+";
				angkaJawab = angka1 + angka2; //tambah
				break;
			case 1:
				operatorRandStr = "-";
				angkaJawab = angka1 - angka2; //kurang
				break;
			case 2:
				operatorRandStr = "*";
				angkaJawab = angka1 * angka2; //kali
				break;
			case 3:
				operatorRandStr = "/";
				if (angka1 > angka2 && angka2 != 0) {
					angkaJawab = angka1 / angka2; //bagi
				} else {
					angkaJawab = 10; //biar ga masuk
				}
				break;
			default:
				operatorRandStr = "=";
				Debug.Log ("Randomizer Error");
				angkaJawab = 0;
				break;
			}
				
			if (angkaJawab <= 9 && angkaJawab >= 0 && angkaJawab % 1 == 0) {
				break;
			}
		}

		ui_text.text = angka1.ToString () + " " + operatorRandStr + " " + angka2.ToString () + " = ?";  

		yield return 0;
	}

	public void callBuatSoal () {
		StartCoroutine (IbuatSoal ());
	}

	public void stopBuatSoal () {
	 	StopCoroutine (IbuatSoal ());
	}

	public int generateJawaban() {
		if (ansLeftTillFixed <= 0) {
			ansLeftTillFixed = fixedAnsWhen;
			return angkaJawab;
		} else {
			ansLeftTillFixed--;
			return Random.Range (0, 9);
		}
	}
}
