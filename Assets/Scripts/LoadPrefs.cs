using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPrefs : MonoBehaviour
{
    public string NPoint;
    public Button loadBtn;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = loadBtn.GetComponent<Button>();
        Text txt = countText.GetComponent<Text>();
        btn.onClick.AddListener(DoLoad);
        

    }

    void DoLoad()
    {
        if (PlayerPrefs.HasKey("NPoint"))
        {
            NPoint = PlayerPrefs.GetString("NPoint");
            countText.text = NPoint;
        }         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
