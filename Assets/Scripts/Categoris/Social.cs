using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float social = 50f;
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
            social -= decreaseCount;
        }
    }

    private void Update()
    {
        if (triggerdLevelFinishd) { return; }
        if (social > 99 || social < 1)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            Debug.Log("Lose By Social");
            triggerdLevelFinishd=true;
        }
        else if (social > 80 || social < 20)
        {
            GetComponent<Animator>().SetBool("inDanger", true);
        }
        else { GetComponent<Animator>().SetBool("inDanger", false); }

        GetComponent<Slider>().value = social;
    }

    public void EffectSocial(float effectSocial)
    {
        social += effectSocial;
    }
    public void StopSlider()
    {
        StopAllCoroutines();
    }
}
