using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float social = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            social -= decreaseCount;
        }
    }

    private void Update()
    {
        if (social > 80 || social < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = social;
    }

    public void EffectSocial(float effectSocial)
    {
        social += effectSocial;
    }
}
