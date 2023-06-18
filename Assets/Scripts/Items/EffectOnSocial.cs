using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnSocial : MonoBehaviour
{
    [SerializeField] float socialEffect = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<Item>().IsBurned())
        {

            FindObjectOfType<Social>().EffectSocial(socialEffect);
        }
    }
}
