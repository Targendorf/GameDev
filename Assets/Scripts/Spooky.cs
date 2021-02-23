using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spooky : Monster {
    public float speed;
    private Vector3 target = new Vector3(14.47f, -2.73f, 11.67969f);
	new void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y != -2.73f)
        {
            target.y = -2.73f;
        }
        else if (transform.position == target && target.y == -2.73f)
        {
            target.y = -1.52f;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Bear character = collider.GetComponent<Bear>();

        if (character)
        {
            character.ReceiveDamage();
        }
    }
}
