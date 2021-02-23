using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPref : SavePref
{
    public Text namePlayer;
    // Start is called before the first frame update
    void Start()
    {
        namePlayer.text = PlayerPrefs.GetString("Name");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
