using UnityEngine;
using System.Collections;
public class Wisp : MonoBehaviour
{  
private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Bear)
        {
            unit.ReceiveDamage();
        }
    }
}
