using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleanliness : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float cleanliness = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            cleanliness -= decreaseCount;
        }
    }

    private void Update()
    {
        if (cleanliness > 80 || cleanliness < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = cleanliness;
    }

    public void EffectCleanliness(float EffectHealth)
    {
        cleanliness += EffectHealth;
    }
}
