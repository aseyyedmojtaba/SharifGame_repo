using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Communications : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float communications = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            communications -= decreaseCount;
        }
    }

    private void Update()
    {
        if (communications > 80 || communications < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = communications;
    }

    public void EffectCommunications(float EffectHealth)
    {
        communications += EffectHealth;
    }
}
