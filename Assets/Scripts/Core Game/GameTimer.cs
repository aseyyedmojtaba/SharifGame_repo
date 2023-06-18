using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our lelel time in SECONDS")]
    [SerializeField] float levelTime = 120f;
    [SerializeField] ClockHand hand;
    bool triggerdLevelFinishd = false;

    // Update is called once per frame
    void Update()
    {
        if (triggerdLevelFinishd) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        hand.SetHandelRotation(Time.timeSinceLevelLoad / levelTime);
        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetTimerFinished();
            triggerdLevelFinishd = true;
            Debug.Log("TimeOut");
            var attackerSpawner = FindObjectOfType<ObjSpawner>();
            attackerSpawner.StopSpawning();
        }
    }

    public float GetTime()
    {
        return GetComponent<Slider>().value;
    }

}
