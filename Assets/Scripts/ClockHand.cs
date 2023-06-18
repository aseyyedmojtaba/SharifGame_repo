using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public void SetHandelRotation(float time)
    {
        float zAngel=time*360;
        transform.rotation=Quaternion.Euler (0,0,-zAngel);
    }
}
