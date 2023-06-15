using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ElectricLine : MonoBehaviour
{
    // Variables
    private bool isActive = false;
    private Color deActiveColor = Color.white;
    private Color activeColor = Color.red;

    private void Start()
    {
        Application.targetFrameRate = 45;
    }
    [SerializeField] BurnScoreDisplay lineScore;
    [SerializeField] private float maxDistance = 5f;   // the maximum distance to check for nearby objects
    [SerializeField] private float roundTo = 10f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Set the color of the object based on whether it's active or not
        if (isActive == true)
        {
            GetComponent<Renderer>().material.color = activeColor;
        }
        if (isActive == false)
        {
            GetComponent<Renderer>().material.color = deActiveColor;
        }
    }

    // Called when another object enters the trigger area
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // If the electric line is active and the other object is not already burned
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            // Burn the other object and add to the score
            otherCollider.gameObject.GetComponent<Item>().Burn();
            FindObjectOfType<Score>().AddToScore(5);
            lineScore.ShowScoreNearLine(5);
        }
    }

    // Called every frame while another object is within the trigger area
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        // If the electric line is active and the other object is not already burned
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            // Burn the other object and calculate the score based on its distance from the electric line
            otherCollider.gameObject.GetComponent<Item>().Burn();
            float distance = Vector3.Distance(this.transform.position, otherCollider.transform.position);
            float score = RoundToNearestMultipleOfRundTo(100 - (distance / maxDistance * 100));
            FindObjectOfType<Score>().AddToScore(score);
            lineScore.ShowScoreNearLine(Convert.ToInt32(score));
        }
    }

    // Round a number to the nearest multiple of roundTo
    public float RoundToNearestMultipleOfRundTo(float number)
    {
        float rounded = (float)Mathf.Round(number / roundTo);
        rounded *= roundTo;
        return rounded;
    }

    // Set the electric line to active or inactive
    public void SetActive(bool active)
    {
        isActive = active;
    }
}