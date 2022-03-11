using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenGummy : MonoBehaviour
{
    public GameObject[] gummies;
    private int gummyChoice = 0;
    private bool mouseInput;

    public static int gummiesTotal;

    public static GameObject chosenPlayer;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        gummiesTotal = 3;
        gummies[3].SetActive(false);
        gummies[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.puzz1Solved)
        {
            gummiesTotal += 1;
            GameManager.puzz1Solved = false;
        }
        if (Player.powderSolved)
        {
            gummiesTotal = 5;
        }

        if (!Player.grouped)
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
            }

            if (!mouseInput)
            {
                chosenPlayer = gummies[gummyChoice];
            }
    }

}

    public void GummyNumbers()
    {
        if (gummiesTotal == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.mouseScrollDelta.y == 1)
            {
                mouseInput = false;
                if (gummyChoice < 2)
                {
                    gummyChoice += 1;
                }
                else
                {
                    gummyChoice = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.mouseScrollDelta.y == -1)
            {
                mouseInput = false;
                if (gummyChoice > 0)
                {
                    gummyChoice -= 1;
                }
                else
                {
                    gummyChoice = 2;
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
        }
        else if (gummiesTotal == 4)
        {
            gummies[3].SetActive(true);
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.mouseScrollDelta.y == 1)
            {
                mouseInput = false;
                if (gummyChoice < 3)
                {
                    gummyChoice += 1;
                }
                else
                {
                    gummyChoice = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.mouseScrollDelta.y == -1)
            {
                mouseInput = false;
                if (gummyChoice > 0)
                {
                    gummyChoice -= 1;
                }
                else
                {
                    gummyChoice = 3;
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
        }
        else if (gummiesTotal == 5)
        {
            gummies[4].SetActive(true);

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.mouseScrollDelta.y == 1)
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
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.mouseScrollDelta.y == -1)
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
}
