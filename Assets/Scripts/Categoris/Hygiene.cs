using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hygiene : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float hygiene = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            hygiene -= decreaseCount;
        }
    }

    private void Update()
    {
        if (hygiene > 80 || hygiene < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = hygiene;
    }

    public void EffectHygiene(float effectHygiene)
    {
        hygiene += effectHygiene;
    }
}
