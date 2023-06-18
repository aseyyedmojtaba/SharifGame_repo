using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnHunger : MonoBehaviour
{
    [SerializeField] float hungerEffect = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<Item>().IsBurned())
        {

            FindObjectOfType<Hunger>().EffectHunger(hungerEffect);
        }
    }

}
