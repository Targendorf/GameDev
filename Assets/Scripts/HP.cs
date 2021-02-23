﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
    private Transform[] hearts = new Transform[3];
    private Bear bear;
    private void Awake()
    {
        bear = FindObjectOfType<Bear>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < bear.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
