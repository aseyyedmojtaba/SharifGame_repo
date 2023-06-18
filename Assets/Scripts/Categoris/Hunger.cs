using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float hunger = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            hunger -= decreaseCount;
        }
    }

    private void Update()
    {
        if (hunger > 80 || hunger < 20)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = hunger;
    }

    public void EffectHunger(float effectHunger)
    {
        hunger += effectHunger;
    }
}
