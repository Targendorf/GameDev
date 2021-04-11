using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PlussOne : MonoBehaviour
{
    public Button plsBtn;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        Text txt = countText.GetComponent<Text>();
        Button btn = plsBtn.GetComponent<Button>();
        plsBtn.onClick.AddListener(PlsO);
        
    }

    void PlsO()
    {
        countText.text = countText.text + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
