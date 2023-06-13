using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int score=0;

    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void AddToScore(float score)
    {
        this.score += Convert.ToInt32(score);
    }
    private void Update()
    {
        text.text=score.ToString();
    }


}
