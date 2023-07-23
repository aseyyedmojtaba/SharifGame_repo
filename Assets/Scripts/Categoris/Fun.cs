using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fun : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float fun = 50f;
    bool triggerdLevelFinishd = false;

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
        if (triggerdLevelFinishd) { return; }
        if (fun > 99 || fun < 1)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            Debug.Log("Lose By Fun");
            triggerdLevelFinishd=true;
        }
        else if (fun > 80 || fun < 20)
        {
            GetComponent<Animator>().SetBool("inDanger", true);
        }
        else { GetComponent<Animator>().SetBool("inDanger", false); }

        GetComponent<Slider>().value = fun;
    }

    public void EffectFun(float effectFun)
    {
        fun += effectFun;
    }
    public void StopSlider()
    {
        StopAllCoroutines();
    }
}
