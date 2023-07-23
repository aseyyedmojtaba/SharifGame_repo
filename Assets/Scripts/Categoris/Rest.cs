using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rest : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float rest = 50f;
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
            rest -= decreaseCount;
        }
    }

    private void Update()
    {
        if (triggerdLevelFinishd) { return; }
        if (rest > 99 || rest < 1)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            Debug.Log("Lose By Rest");
            triggerdLevelFinishd=true;
        }
        else if (rest > 80 || rest < 20)
        {
            GetComponent<Animator>().SetBool("inDanger", true);
        }
        else { GetComponent<Animator>().SetBool("inDanger", false); }

        GetComponent<Slider>().value = rest;
    }

    public void EffectRest(float EffectHealth)
    {
        rest += EffectHealth;
    }
    public void StopSlider()
    {
        StopAllCoroutines();
    }
}
