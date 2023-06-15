using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class BurnScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "";
    }
    public void ShowScoreNearLine(int score)
    {
        StartCoroutine(ShowAndHideScore(score));
    }
    public IEnumerator ShowAndHideScore(int score)
    {

        scoreText.text = score.ToString();
        yield return new WaitForSeconds(0.4f);
        scoreText.text = "";
    }

}
