using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collider)
    {
        Bear bear = collider.GetComponent<Bear>();
        if (bear)
        {
            bear.Lives++;
            Destroy(gameObject);
        }
    }
}
