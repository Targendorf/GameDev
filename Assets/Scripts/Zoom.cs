using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    public float zoom = 5F;
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 3)
        {
            zoom -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 9)
        {
            zoom += 1;
        }
        GetComponent<Camera>().orthographicSize = zoom;
    }
}
