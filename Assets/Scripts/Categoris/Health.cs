using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float health = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            health -= decreaseCount;
        }
    }
   
    private void Update()
    {
        if (health > 80 || health < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = health;
    }

    public void EffectHealth(float EffectHealth)
    {
        health += EffectHealth;
    }
}
