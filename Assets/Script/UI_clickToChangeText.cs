using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_clickToChangeText : MonoBehaviour {

	[SerializeField] Text[] textList;
	int activatedObj = 0;

	void Start () {
		foreach (Text list in textList) {
			list.gameObject.SetActive (false);
		}

		if (textList [activatedObj] != null) {
			textList [activatedObj].gameObject.SetActive (true);
		}
	}
	
	void Update () {
		if (Input.GetMouseButton (0)) {
			textList [activatedObj].gameObject.SetActive (false);
			activatedObj++;
			if (textList [activatedObj] != null) {
				textList [activatedObj].gameObject.SetActive (true);
			} else {
				Debug.Log ("Text abis");
			}
		}
	}
}
