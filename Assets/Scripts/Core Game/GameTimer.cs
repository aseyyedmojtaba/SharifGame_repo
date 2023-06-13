using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our lelel time in SECONDS")]
    [SerializeField] float levelTime = 120f;
    bool triggerdLevelFinishd = false;

    // Update is called once per frame
    void Update()
    {
        if (triggerdLevelFinishd) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            //FindObjectOfType<LevelController>().SetTimerFinished();
            triggerdLevelFinishd = true;
            Debug.Log("TimeOut");
            //var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
            //foreach (AttackerSpawner spawner in attackerSpawners)
            //{
            //    spawner.StopSpawning();
            //}
        }
    }
}
