using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowRing : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpinRing());
    }
    IEnumerator SpinRing()
    {
        float zRotate = 0;
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, zRotate);
            yield return new WaitForSeconds(.1f);
            zRotate += 10;
        }
    }

}
