﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDestroy : MonoBehaviour {
	void Start () {
        if (GameObject.FindGameObjectsWithTag("Audio").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
	}
}
