using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour {
    public float speed;
    private Vector3 target = new Vector3(0,1.68f, 0);
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y != 0.81f)
        {
            target.y = 0.81f;
        }
        else if (transform.position == target && target.y == 0.81f)
        {
            target.y = 1.68f;
        }
    }
}
