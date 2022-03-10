using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool pressed;

    public SpriteRenderer button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.gameObject.layer == 7)
        {
            pressed = true;
            button.color = Color.green;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.gameObject.layer == 7)
        {
            pressed = true;
            button.color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.gameObject.layer == 7)
        {
            pressed = false;
            button.color = Color.red;
        }
    }
}
