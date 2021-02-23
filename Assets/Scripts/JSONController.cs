using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONController : MonoBehaviour
{

    public Score score;

    [ContextMenu("Load")]
    public void LoadField(){
        score = JsonUtility.FromJson<Score>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
    }

    [ContextMenu("Save")]
    public void SaveField(){
        File.WriteAllText(Application.streamingAssetsPath + "JSON.json", JsonUtility.ToJson(score));
    }

    [System.Serializable]
    public class Score
    {
        public int ScoreCoin;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
