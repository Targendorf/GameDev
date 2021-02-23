using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePref : MonoBehaviour
{
 public InputField name;
 public string plyName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plyName = name.text;
        PlayerPrefs.SetString("Name", plyName);
    PlayerPrefs.Save();
    }
    private void Awake()
{
        DontDestroyOnLoad(this);
}
}
