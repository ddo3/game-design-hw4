﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTombstone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0,5,0);
	}
}
