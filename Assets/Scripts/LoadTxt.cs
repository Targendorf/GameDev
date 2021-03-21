using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadTxt : MonoBehaviour
{
    public Button loadBtn;
    public string fileName = "SaveData";
    public Text loadString;
    // Start is called before the first frame update
    void Start()
    {
        Text txt = loadString.GetComponent<Text>();
        Button btn = loadBtn.GetComponent<Button>();
        btn.onClick.AddListener(LoadFile);
    }

    void LoadFile()
    {
        if (File.Exists(Application.dataPath + "/" + fileName + ".txt"))
        {
            string[] rows = File.ReadAllLines(Application.dataPath + "/" + fileName + ".txt");
            loadString.text = rows[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
