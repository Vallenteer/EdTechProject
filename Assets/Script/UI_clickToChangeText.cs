using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_clickToChangeText : MonoBehaviour {

	[SerializeField] GameObject gatotAnimation;
	[SerializeField] Text[] textList;
	int activatedObj = 0;

	void Start () {
		foreach (Text list in textList) {
			list.gameObject.SetActive (false);
		}

		if (textList [activatedObj] != null) {
			textList [activatedObj].gameObject.SetActive (true);
		}

		gatotAnimation.SetActive(false);
	}
	
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			textList [activatedObj].gameObject.SetActive (false);
			activatedObj++;
			if (textList.Length>activatedObj) {
				textList [activatedObj].gameObject.SetActive (true);
			} else {
				gatotAnimation.SetActive(true);
				//Debug.Log ("Text abis");
			}
		}
	}
}
