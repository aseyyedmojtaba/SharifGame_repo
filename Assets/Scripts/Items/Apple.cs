using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] float healthEffect = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<Item>().IsBurned())
        {
            
            FindObjectOfType<Health>().EffectHealth(healthEffect);
        }
    }

}
