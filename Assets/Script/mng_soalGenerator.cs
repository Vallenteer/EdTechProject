using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_soalGenerator : MonoBehaviour {

	[Header("Ref")]
	mng_playerStat statScript;

	[Header("UI Text Object")]
	[SerializeField] Text ui_text;

	[Header("Properties")]
	[SerializeField] int angka1;
	[SerializeField] int angka2;
	[SerializeField] int angka3;
	[SerializeField] public int angkaJawab;
	int levelkeCounter;

	[Header("Manipulator")]
	[SerializeField] int fixedAnsWhen = 4;
	int ansLeftTillFixed;

	void Start () {
		statScript = this.GetComponent<mng_playerStat> ();
		levelkeCounter = statScript.getLevelKe ();
		ansLeftTillFixed = fixedAnsWhen;
		StartCoroutine (IbuatSoal ());
	}
		
	IEnumerator IbuatSoal(){
		ui_text.text = "Loading..."; //Placeholder pas lagi random soal
		int operatorRand;
		string operatorRandStr1 = "";
		string operatorRandStr2 = "";
	
		while (true) {
			
			switch (levelkeCounter) {
			case 1:
				operatorRand = Random.Range (0, 1);
				angka1 = Random.Range (0, 9);
				angka2 = Random.Range (0, 9);
				switch (operatorRand) {
				case 0:
					operatorRandStr1 = "+";
					angkaJawab = angka1 + angka2; //tambah
					break;
				case 1:
					operatorRandStr1 = "-";
					angkaJawab = angka1 - angka2; //kurang
					break;
				default :
					Debug.Log ("Something Wrong");
					break;
				}
				ui_text.text = angka1.ToString () + " " + operatorRandStr1 + " " + angka2.ToString () + " = ?";  
				break;

			case 2:
				operatorRand = Random.Range (0, 3);
				angka1 = Random.Range (0, 9);
				angka2 = Random.Range (0, 9);
				angka3 = Random.Range (0, 9);

				switch (operatorRand) {
				case 0:
					operatorRandStr1 = "+";
					operatorRandStr2 = "-";
					angkaJawab = angka1 + angka2 - angka3;
					break;
				case 1:
					operatorRandStr1 = "-";
					operatorRandStr2 = "+";
					angkaJawab = angka1 - angka2 + angka3;
					break;
				case 2:
					operatorRandStr1 = "+";
					operatorRandStr2 = "+";
					angkaJawab = angka1 + angka2 + angka3;
					break;
				case 3:
					operatorRandStr1 = "-";
					operatorRandStr2 = "-";
					angkaJawab = angka1 - angka2 - angka3;
					break;
				default :
					Debug.Log ("Something Wrong");
					break;
				}
				ui_text.text = angka1.ToString () + " " + operatorRandStr1 + " " + angka2.ToString () + " " + operatorRandStr2 + " " + angka3.ToString () + " = ?";  
				break;

			case 3:
				angka1 = Random.Range (0, 9);
				angka2 = Random.Range (0, 9);
				operatorRandStr1 = "x";
				angkaJawab = angka1 * angka2;
				ui_text.text = angka1.ToString () + " " + operatorRandStr1 + " " + angka2.ToString () + " = ?";  
				break;
			
			default:
				ui_text.text = "Error (Tembak angka 0 Mode)";
				Debug.Log ("Scene Error");
				angkaJawab = 0;
				break;
			}
				
			if (angkaJawab <= 99 && angkaJawab >= 0 && angkaJawab % 1 == 0) {
				break;
			}
		}

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
			if (angkaJawab <= 12) {
				return Random.Range (0, 12);
			} else {
				return Random.Range (angkaJawab-10, angkaJawab+9); //max num == 81 (9x9), max Rand =90
			}
		}
	}
}
