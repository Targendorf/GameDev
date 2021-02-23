using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    void OnTriggerEnter2D (Collider2D col)
    {
        ScoreCoin.scoreAmount += 1;
        Destroy(gameObject);
    }
}
