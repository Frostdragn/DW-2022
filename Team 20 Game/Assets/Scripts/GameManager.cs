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

    //public GameObject bag1;
    public GameObject bag2;
    public GameObject bag3;
    public GameObject bag4;

    // Start is called before the first frame update
    void Start()
    {
        
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

            bag4.SetActive(true);
        }
        else
        {
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
}
