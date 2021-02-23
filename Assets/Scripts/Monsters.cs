using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : Unit
{
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bear character = collider.GetComponent<Bear>();

        if (character)
        {
            character.ReceiveDamage();
        }
    }
}

