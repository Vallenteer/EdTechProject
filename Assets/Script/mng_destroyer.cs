﻿using UnityEngine;
using System.Collections;

public class mng_destroyer : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D other){
		Destroy (other.gameObject);
	}
}
