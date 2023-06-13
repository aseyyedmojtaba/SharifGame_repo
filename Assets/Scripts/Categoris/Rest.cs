using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rest : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float rest = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            rest -= decreaseCount;
        }
    }

    private void Update()
    {
        if (rest > 80 || rest < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = rest;
    }

    public void EffectRest(float EffectHealth)
    {
        rest += EffectHealth;
    }
}
