using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnRest : MonoBehaviour
{
    [SerializeField] float restEffect = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<Item>().IsBurned())
        {

            FindObjectOfType<Rest>().EffectRest(restEffect);
        }
    }
}
