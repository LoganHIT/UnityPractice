using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class HealthEffect : MonoBehaviour
{
    //takes in a variable from the trigger
    [SerializeField] private int healthEffect;

    //This is a built in mechanic for trigger colliders
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //Checks the tag of the other collider entered into
    //    if(other.tag == ("Player") || other.gameObject.layer == LayerMask.NameToLayer("Mob"))
    //    {
    //        if(healthEffect > 0)
    //        {
    //            other.gameObject.GetComponent<HealthManager>().Heal(healthEffect);
    //        }
    //        else if(healthEffect < 0)
    //        {
    //            //.Abs is the absolute value
    //            other.gameObject.GetComponent<HealthManager>().TakeDamage(Mathf.Abs(healthEffect));
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (healthEffect > 0)
            {
                collision.gameObject.GetComponent<HealthManager>().Heal(healthEffect);
            }
            else if (healthEffect < 0)
            {
                //.Abs is the absolute value
                collision.gameObject.GetComponent<HealthManager>().TakeDamage(Mathf.Abs(healthEffect));
            }
        }
        
    }
}
