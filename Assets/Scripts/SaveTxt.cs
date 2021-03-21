using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveTxt : MonoBehaviour
{
    public Button saveBtn;
    public string fileName = "SaveData";
    public Text saveString;
    // Start is called before the first frame update
    void Start()
    {
        Text txt = saveString.GetComponent<Text>();
        Button btn = saveBtn.GetComponent<Button>();
        btn.onClick.AddListener(SaveFile);
    }
    void SaveFile()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + fileName + ".txt");
        string sp = " ";
        sw.WriteLine(saveString.text);
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
