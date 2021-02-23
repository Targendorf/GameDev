using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spooky1 : Monster {
    public float speed;
    private Vector3 target = new Vector3(119.77f, 6.29f, 11.67969f);
	new void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y != 6.29f)
        {
            target.y = 6.29f;
        }
        else if (transform.position == target && target.y == 6.29f)
        {
            target.y = 7.43f;
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

