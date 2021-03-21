using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePrefs : MonoBehaviour
{
    public Button saveBtn;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        Text txt = countText.GetComponent<Text>();
        Button btn = saveBtn.GetComponent<Button>();
        btn.onClick.AddListener(DoSave);

    }

    void DoSave()
    {
        PlayerPrefs.SetString("NPoint", countText.text);

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
