using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LineScore : MonoBehaviour
{
    [SerializeField] private float timeToShow = .5f;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowThis(int score)
    {
        StartCoroutine(ShowAndDellete(score));
    }
    private IEnumerator ShowAndDellete(int score)
    {
        if (score == 100)
        {
            text.color = Color.green;
        }
        text.text = score.ToString();
        yield return new WaitForSeconds(timeToShow);
        text.text = null;
        text.color = Color.white;
    }
}
