using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hygiene : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float hygiene = 50f;
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
            hygiene -= decreaseCount;
        }
    }

    private void Update()
    {
        if (triggerdLevelFinishd) { return; }
        if (hygiene > 99 || hygiene < 1)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            Debug.Log("Lose By Hygiene");
            triggerdLevelFinishd=true;
        }
        else if (hygiene > 80 || hygiene < 20)
        {
            GetComponent<Animator>().SetBool("inDanger", true);
        }
        else { GetComponent<Animator>().SetBool("inDanger", false); }

        GetComponent<Slider>().value = hygiene;
    }

    public void EffectHygiene(float effectHygiene)
    {
        hygiene += effectHygiene;
    }
    public void StopSlider()
    {
        StopAllCoroutines();
    }
}
