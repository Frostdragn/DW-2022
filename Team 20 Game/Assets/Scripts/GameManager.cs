using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject tutorButton;
    public GameObject tutorWall;

    public GameObject puzz1b1;
    public GameObject puzz1b2;
    public GameObject puzz1b3;
    public GameObject puzz1Gate;
    public GameObject puzz1Bear;
    public static bool puzz1Solved;

    public GameObject redBear;
    public static bool redBearFree;

    //puzzle 2 space
    public GameObject puzz2Mouse;
    //

    public GameObject puzz3b1;
    public GameObject puzz3b2;
    public GameObject puzz3Powder1;

    public GameObject bag1;
    public GameObject bag2;
    public GameObject bag3;
    public GameObject bag4;

    // Start is called before the first frame update
    void Start()
    {
        puzz3Powder1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Bags();

        bool tutorB = tutorButton.GetComponent<ButtonScript>().pressed;

        if (tutorB)
        {
            tutorWall.SetActive(false);
        }
        else if (!tutorB)
        {
            tutorWall.SetActive(true);
        }

        Puzzle1();

        Puzzle3();

    }

    public void Bags()
    {
        if (!Player.grouped)
        {
            if (redBearFree)
            {
                bag2.SetActive(true);
                bag3.SetActive(true);
            }
            else
            {
                bag2.SetActive(false);
                bag3.SetActive(false);
            }

            bag1.SetActive(true);
            bag4.SetActive(true);
        }
        else
        {
            bag1.SetActive(false);
            bag2.SetActive(false);
            bag3.SetActive(false);
            bag4.SetActive(false);
        }
    }

    public void Puzzle1()
    {
        bool puzz1B1 = puzz1b1.GetComponent<ButtonScript>().pressed;
        bool puzz1B2 = puzz1b2.GetComponent<ButtonScript>().pressed;
        bool puzz1B3 = puzz1b3.GetComponent<ButtonScript>().pressed;

        if (puzz1B1 && puzz1B2 && puzz1B3 && ChosenGummy.gummiesTotal == 3)
        {
            puzz1Gate.SetActive(false);
            puzz1Bear.SetActive(false);
            puzz1Solved = true;
        }
        else if (puzz1B1 && puzz1B2 && puzz1B3 && ChosenGummy.gummiesTotal == 4)
        {
            puzz1Gate.SetActive(false);
        }
        else
        {
            puzz1Gate.SetActive(true);
        }

        if (redBear.transform.position.x > 113)
        {
            redBearFree = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionCheck = collision.gameObject;

        if (collision.tag == "Cheese")
        {
            puzz2Mouse.SetActive(false);
        }
    }

    public void Puzzle3()
    {
        bool puzz3B1 = puzz3b1.GetComponent<ButtonScript>().pressed;

        if (puzz3B1)
        {
            puzz3Powder1.SetActive(true);
        }
    }
}
