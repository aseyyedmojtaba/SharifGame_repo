using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricLine : MonoBehaviour
{
    private bool isActive = false;
    private Color deActiveColor = Color.white;
    private Color activeColor = Color.red;
    [SerializeField] public float maxDistance = 5f;   // the maximum distance to check for nearby objects
    [SerializeField] float roundTo = 10f;
    [SerializeField] GameObject ga;

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            GetComponent<Renderer>().material.color = activeColor;
            RemoveNearbyObjects();
        }
        if (isActive == false)
        {
            GetComponent<Renderer>().material.color = deActiveColor;
        }


    }
    public List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
    void RemoveNearbyObjects()
    {
        foreach (GameObject obj in GetAllChilds(FindObjectOfType<ObjSpawner>().gameObject))
        {
            float distance = Vector3.Distance(this.transform.position, obj.transform.position);
            if (distance < maxDistance && !obj.GetComponent<Item>().IsBurned())
            {
                obj.GetComponent<Item>().Burn();
                FindAnyObjectByType<Score>().AddToScore(RoundToNearestMultipleOfRundTo(100 - (distance / maxDistance * 100)));
            }

        }

    }
    public float RoundToNearestMultipleOfRundTo(float number)
    {
        if (number >=15 && number<=16)
        {
            return 0;
            //این کامنت فقط برای پاک شدن نوشته شده است...
        }
            
        float rounded = (float)Mathf.Round(number / roundTo) * roundTo;
        return rounded;
    }


    public void SetActive(bool active)
    {
        isActive = active;
    }


}
