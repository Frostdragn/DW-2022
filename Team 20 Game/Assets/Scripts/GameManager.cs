using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject tutorButton;
    public GameObject tutorWall;

    //puzzle 1
    public GameObject puzz1b1;
    public GameObject puzz1b2;
    public GameObject puzz1b3;
    public GameObject puzz1Gate;
    public GameObject puzz1Bear;
    public static bool puzz1Solved;

    public GameObject redBear;
    public static bool redBearFree;

    //puzzle 2
    public GameObject puzz3b1;
    public GameObject puzz3b2;
    public GameObject puzz3b3;
    public GameObject puzz3b4;
    public GameObject puzz3b5;
    public GameObject puzz3b6;
    public GameObject puzz3b7;

    public GameObject puzz3Powder1;
    public GameObject puzz3Powder2;
    public GameObject puzz3Powder3;
    public GameObject puzz3Powder4;
    public GameObject puzz3Powder5;
    public GameObject puzz3Powder6;

    private bool powder2;
    private bool powder3;
    private bool powder4;
    private bool powder5;
    private bool powder6;


    public GameObject puzz3Wall;

    public GameObject bag1;
    public GameObject bag2;
    public GameObject bag3;
    public GameObject bag4;

    // Start is called before the first frame update
    void Start()
    {
        puzz3Powder1.SetActive(false);
        puzz3Powder2.SetActive(false);
        puzz3Powder3.SetActive(false);
        puzz3Powder4.SetActive(false);
        puzz3Powder5.SetActive(false);
        puzz3Powder6.SetActive(false);
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

    public void Puzzle3()
    {
        bool puzz3B1 = puzz3b1.GetComponent<ButtonScript>().pressed;
        bool puzz3B2 = puzz3b2.GetComponent<ButtonScript>().pressed;
        bool puzz3B3 = puzz3b3.GetComponent<ButtonScript>().pressed;
        bool puzz3B4 = puzz3b4.GetComponent<ButtonScript>().pressed;
        bool puzz3B5 = puzz3b5.GetComponent<ButtonScript>().pressed;
        bool puzz3B6 = puzz3b6.GetComponent<ButtonScript>().pressed;
        bool puzz3B7 = puzz3b7.GetComponent<ButtonScript>().pressed;
        //bool puzz3B5 = puzz3b8.GetComponent<ButtonScript>().pressed;

        //part 1
        if (puzz3B1)
        {
            puzz3Powder1.SetActive(true);
        }

        if (puzz3B2)
        {
            puzz3Wall.SetActive(false);
        }
        else
        {
            puzz3Wall.SetActive(true);
        }

        //Part 2
        if (puzz3B3)
        {
            if (powder3)
            {
                puzz3Powder2.SetActive(true);
                powder2 = true;
            }
            else
            {
                puzz3Powder3.SetActive(true);
                powder3 = true;
            }

        }
        if (puzz3B4)
        {
            if (powder3)
            {
                puzz3Powder2.SetActive(true);
                powder2 = true;
            }
            else
            {
                puzz3Powder3.SetActive(true);
                powder3 = true;
            }
        }

        //Part 3
        if (puzz3B5)
        {
            if (!powder4)
            {
                puzz3Powder4.SetActive(true);
                powder4 = true;
            }
            else if (powder4 && !powder5)
            {
                puzz3Powder5.SetActive(true);
                powder5 = true;
            }
            else if (powder4 && powder5 && !powder6)
            {
                puzz3Powder6.SetActive(true);
                powder6 = true;
            }
        }
        if (puzz3B6)
        {
            if (!powder4)
            {
                puzz3Powder4.SetActive(true);
                powder4 = true;
            }
            else if (powder4 && !powder5)
            {
                puzz3Powder5.SetActive(true);
                powder5 = true;
            }
            else if (powder4 && powder5 && !powder6)
            {
                puzz3Powder6.SetActive(true);
                powder6 = true;
            }
        }
        if (puzz3B7)
        {
            if (!powder4)
            {
                puzz3Powder4.SetActive(true);
                powder4 = true;
            }
            else if (powder4 && !powder5)
            {
                puzz3Powder5.SetActive(true);
                powder5 = true;
            }
            else if (powder4 && powder5 && !powder6)
            {
                puzz3Powder6.SetActive(true);
                powder6 = true;
            }
        }
    }
}
