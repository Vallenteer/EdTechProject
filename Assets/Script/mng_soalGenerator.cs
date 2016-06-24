using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mng_soalGenerator : MonoBehaviour {

	[Header("UI Text Object")]
	[SerializeField] Text ui_text;

	[Header("Properties")]
	[SerializeField] int angka1;
	[SerializeField] int angka2;
	[SerializeField] public int angkaJawab;
	[SerializeField] int operatorRand;

	[Header("Manipulator")]
	[SerializeField] int fixedAnsWhen = 4;
	int ansLeftTillFixed;

	void Start () {
		ansLeftTillFixed = fixedAnsWhen;
		StartCoroutine (IbuatSoal ());
	}
		
	IEnumerator IbuatSoal(){
		ui_text.text = "Loading..."; //Placeholder pas lagi random soal
		string operatorRandStr;

		while (true) {
			operatorRand = Random.Range (0, 1);
			angka1 = Random.Range (0, 9);
			angka2 = Random.Range (0, 9);
			if (operatorRand == 0) {
				operatorRandStr = "+";
				angkaJawab = angka1 + angka2; //tambah
			} else {
				operatorRandStr = "-";
				angkaJawab = angka1 - angka2; //kurang
			}

			if (angkaJawab <= 9 && angkaJawab >= 0) {
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
