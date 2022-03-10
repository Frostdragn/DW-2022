using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tutorButton;
    public GameObject tutorWall;

    public GameObject puzz1b1;
    public GameObject puzz1b2;
    public GameObject puzz1b3;
    public GameObject puzz1Gate;
    public static bool puzz1Solved;
    private bool puzz1Check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool tutorB = tutorButton.GetComponent<ButtonScript>().pressed;

        if (tutorB)
        {
            tutorWall.SetActive(false);
        }
        else if (!tutorB)
        {
            tutorWall.SetActive(true);
        }

        bool puzz1B1 = puzz1b1.GetComponent<ButtonScript>().pressed;
        bool puzz1B2 = puzz1b2.GetComponent<ButtonScript>().pressed;
        bool puzz1B3 = puzz1b3.GetComponent<ButtonScript>().pressed;

        if (puzz1B1 && puzz1B2 && puzz1B3 && ChosenGummy.gummiesTotal == 3)
        {
            puzz1Gate.SetActive(false);
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
    }
}
