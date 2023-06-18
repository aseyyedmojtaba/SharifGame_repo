using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnHygiene : MonoBehaviour
{
    [SerializeField] float hygieneEffect = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<Item>().IsBurned())
        {

            FindObjectOfType<Hygiene>().EffectHygiene(hygieneEffect);
        }
    }
}
