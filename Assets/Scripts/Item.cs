using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] float speed = 5f; //  سرعت حرکت آبجکت بعدا باید در متدی بیاد و توسط اسپونر مقدار دهی بشه 
    [SerializeField] Color burnedColor= Color.gray;
    private Rigidbody2D rb;
    private bool burned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shereder"))
        {
            Destroy(gameObject);
        }
    }

    public void Burn()
    {
        burned=true;
        GetComponent<Renderer>().material.color = burnedColor;
    }

    public bool IsBurned()
    {
        return burned;
    }

}
