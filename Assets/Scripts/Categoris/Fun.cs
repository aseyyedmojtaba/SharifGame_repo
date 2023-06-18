using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fun : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float fun = 50f;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            fun -= decreaseCount;
        }
    }

    private void Update()
    {
        if (fun > 80 || fun < 20)
        {
            //Debug.Log("game over");
        }

        GetComponent<Slider>().value = fun;
    }

    public void EffectFun(float effectFun)
    {
        fun += effectFun;
    }
}
