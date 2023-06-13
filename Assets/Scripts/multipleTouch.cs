using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multipleTouch : MonoBehaviour
{
    Collider2D myCollider;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject electricLine;

    float minX;
    float minY;
    float maxX;
    float maxY;

    private void Start()
    {
        Bounds boxBounds = GetComponent<Collider2D>().bounds;
        Vector2 topRight = new Vector2(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y);
        Vector2 bottonLeft = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y);
        minX = bottonLeft.x;
        minY = bottonLeft.y;
        maxX = topRight.x;
        maxY = topRight.y;

    }
    // Update is called once per frame
    void Update()
    {
        int i = 0;
        bool isTouched = false;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (IsTuchingMyCollider(getTouchPosition(t.position)))
            {
                isTouched = true;
                //if (t.phase == TouchPhase.Began)
                //{
                //    //turn on
                //    electricLine.GetComponent<ElectricLine>().SetActive(true);
                //}
                //else if (t.phase == TouchPhase.Ended)
                //{
                //    //turn off
                //    electricLine.GetComponent<ElectricLine>().SetActive(false);
                //}
                //else if (t.phase == TouchPhase.Moved)
                //{
                //    //some thing
                //}
                electricLine.GetComponent<ElectricLine>().SetActive(true);
            }

            ++i;
        }
        if (!isTouched)
        {
            electricLine.GetComponent<ElectricLine>().SetActive(false);
        }
    }

    public bool IsTuchingMyCollider(Vector2 point)
    {

        return (point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY);
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

}