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
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] GameObject burnVFX;
    [SerializeField] LineScore lineScore;
    [SerializeField] private float maxDistance = 5f;   // the maximum distance to check for nearby objects
    [SerializeField] private int roundTo = 10;


    private void Start()
    {
        Application.targetFrameRate = 45;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetEffectVolume();

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        // Set the color of the object based on whether it's active or not
        if (isActive && !animator.GetBool("Thunder"))
        {
            animator.SetBool("Thunder", true);
            audioSource.Play();
        }
        if (!isActive && animator.GetBool("Thunder"))
        {
            animator.SetBool("Thunder", false);
            audioSource.Pause();
        }
    }

    // Called when another object enters the trigger area
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // If the electric line is active and the other object is not already burned
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            // Burn the other object and add to the score
            otherCollider.gameObject.GetComponent<Item>().Burn(burnVFX);
            FindObjectOfType<Score>().AddToScore(5);
            lineScore.ShowThis(5);
        }
    }

    // Called every frame while another object is within the trigger area
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        // If the electric line is active and the other object is not already burned
        if (isActive == true && !otherCollider.gameObject.GetComponent<Item>().IsBurned())
        {
            // Burn the other object and calculate the score based on its distance from the electric line
            otherCollider.gameObject.GetComponent<Item>().Burn(burnVFX);
            float distance = Vector3.Distance(this.transform.position, otherCollider.transform.position);
            int score = RoundToNearestMultipleOfRundTo(100 - (distance / maxDistance * 100));
            FindObjectOfType<Score>().AddToScore(score);
            lineScore.ShowThis(score);
        }
    }

    // Round a number to the nearest multiple of roundTo
    public int RoundToNearestMultipleOfRundTo(float number)
    {
        int rounded = (int)Mathf.Round(number / roundTo);
        rounded *= roundTo;
        return rounded;
    }

    // Set the electric line to active or inactive
    public void SetActive(bool active)
    {
        isActive = active;
    }
    public void PauseAudio()
    {
        audioSource.Pause();
    }
}