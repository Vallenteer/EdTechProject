using UnityEngine;
using System.Collections;

public class mng_hideCursor : MonoBehaviour {

	[SerializeField] bool cursorVisible = true;

	//TODO: Pake Call function jangan lewat update
	void Start(){
		ChangeCursorState ();
	}

	void ChangeCursorState () {
		if (!cursorVisible) {
			Cursor.visible = false;
		} else {
			Cursor.visible = true;
		}
	}
}
