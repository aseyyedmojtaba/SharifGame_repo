using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[0];
    }

    // Update is called once per frame
    public void On()
    {
        renderer.sprite = sprites[1];
    }
    public void Off()
    {
        renderer.sprite = sprites[0];
    }
}
