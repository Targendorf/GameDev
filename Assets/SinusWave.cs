using UnityEngine;
using System.Collections;
 
public class SinusWave : MonoBehaviour {

    public int lengthOfLineRenderer = 20;
    void Start() {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.1F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
    }
    void Update() {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        int i = 0;
        while (i < lengthOfLineRenderer) {
            Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
            lineRenderer.SetPosition(i, pos);
            i++;
        }
    }
}