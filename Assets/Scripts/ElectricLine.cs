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

    private void Start()
    {
        Application.targetFrameRate = 45;
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            GetComponent<Renderer>().material.color = activeColor;
        }
        if (isActive == false)
        {
            GetComponent<Renderer>().material.color = deActiveColor;
        }


    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            otherCollider.gameObject.GetComponent<Item>().Burn();
            FindObjectOfType<Score>().AddToScore(5);
        }
    }
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            otherCollider.gameObject.GetComponent<Item>().Burn();
            float distance = Vector3.Distance(this.transform.position, otherCollider.transform.position);
            FindObjectOfType<Score>().AddToScore(RoundToNearestMultipleOfRundTo(100 - (distance / maxDistance * 100)));
        }
    }
    public float RoundToNearestMultipleOfRundTo(float number)
    {
        float rounded = (float)Mathf.Round(number / roundTo) * roundTo;
        return rounded;
    }


    public void SetActive(bool active)
    {
        isActive = active;
    }


}
