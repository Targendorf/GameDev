using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSpawn : Monster {
    public GameObject respawn;
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Bear character = collider.GetComponent<Bear>();

        if (character)
        {
            character.ReceiveDamage();
        }
        if (collider.tag == "Player")
        {
            collider.transform.position = respawn.transform.position;
        }
    }
}
