using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenGummy : MonoBehaviour
{
    public GameObject[] gummies;
    private int gummyChoice = 0;
    private bool mouseInput;

    public static GameObject chosenPlayer;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GummyNumbers();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            mouseInput = true;
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject != null && targetObject.gameObject.layer == 7)
            {
                chosenPlayer = targetObject.transform.gameObject;
            }
            else
            {
                chosenPlayer = gummies[gummyChoice];
            }
        }
        if (!mouseInput)
        {
            chosenPlayer = gummies[gummyChoice];
        }
    }

    public void GummyNumbers()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mouseInput = false;
            if (gummyChoice < 4)
            {
                gummyChoice += 1;
            }
            else
            {
                gummyChoice = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mouseInput = false;
            if (gummyChoice > 0)
            {
                gummyChoice -= 1;
            }
            else
            {
                gummyChoice = 4;
            }
        }

        if (Input.GetKeyDown("1"))
        {
            mouseInput = false;
            gummyChoice = 0;
        }
        if (Input.GetKeyDown("2"))
        {
            mouseInput = false;
            gummyChoice = 1;
        }
        if (Input.GetKeyDown("3"))
        {
            mouseInput = false;
            gummyChoice = 2;
        }
        if (Input.GetKeyDown("4"))
        {
            mouseInput = false;
            gummyChoice = 3;
        }
        if (Input.GetKeyDown("5"))
        {
            mouseInput = false;
            gummyChoice = 4;
        }
    }
}
