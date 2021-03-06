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

    public GameObject tabSign;

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

    public ParticleSystem powPar1;
    public ParticleSystem powPar2;
    public ParticleSystem powPar3;

    public AudioSource sugarFall;

    private bool b1trig;
    private bool b3trig;
    private bool b4trig;
    private bool b5trig;
    private bool b6trig;
    private bool b7trig;

    private int powderCount2;
    private int powderCount3;

    public GameObject puzz3Wall;

    public GameObject yellowBear;

    public GameObject puzz3Passage;

    public GameObject butQ1;
    public GameObject butQ2;
    public GameObject butQ3;
    public GameObject butQ4;
    public GameObject butQ5;

    public GameObject fudge;
    public GameObject fudgeCheck;
    public GameObject cane;
    public GameObject caneCheck;
    public GameObject lic;
    public GameObject licCheck;
    public GameObject cCrane;

    public static bool craneBuilt;
    public static bool gameWin;

    public GameObject bag1;
    public GameObject bag2;
    public GameObject bag3;
    public GameObject bag4;
    public GameObject bag5;

    // Start is called before the first frame update
    void Start()
    {
        tabSign.SetActive(false);

        puzz3Powder1.SetActive(false);
        puzz3Powder2.SetActive(false);
        puzz3Powder3.SetActive(false);
        puzz3Powder4.SetActive(false);
        puzz3Powder5.SetActive(false);
        puzz3Powder6.SetActive(false);

        puzz3Passage.transform.position = new Vector3(puzz3Passage.transform.position.x, 4.4f, puzz3Passage.transform.position.z);

        fudge.SetActive(false);
        fudgeCheck.SetActive(false);
        cane.SetActive(false);
        caneCheck.SetActive(false);
        lic.SetActive(false);
        licCheck.SetActive(false);
        cCrane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Bags();

        if (Player.powderSolved)
        {
            yellowBear.SetActive(false);
        }
        if (CranePieces.Cpiece)
        {
            puzz3Passage.transform.position = new Vector3(puzz3Passage.transform.position.x, -4.64f, puzz3Passage.transform.position.z);
        }

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

        if (CranePieces.Fpiece && CranePieces.Cpiece && CranePieces.Lpiece)
        {
            fudge.SetActive(false);
            lic.SetActive(false);
            cane.SetActive(false);
            fudgeCheck.SetActive(true);
            caneCheck.SetActive(true);
            licCheck.SetActive(true);

            craneBuilt = true;
            cCrane.SetActive(true);
        }
        else if (CranePieces.Fpiece && CranePieces.Cpiece)
        {
            fudge.SetActive(true);
            cane.SetActive(true);
            fudgeCheck.SetActive(true);
            caneCheck.SetActive(true);
        }
        else if (CranePieces.Fpiece && CranePieces.Lpiece)
        {
            fudge.SetActive(true);
            lic.SetActive(true);
            fudgeCheck.SetActive(true);
            licCheck.SetActive(true);
        }
        else if (CranePieces.Fpiece)
        {
            fudge.SetActive(true);
            fudgeCheck.SetActive(true);
        }

        bool Qbutton1 = butQ1.GetComponent<ButtonScript>().pressed;
        bool Qbutton2 = butQ2.GetComponent<ButtonScript>().pressed;
        bool Qbutton3 = butQ3.GetComponent<ButtonScript>().pressed;
        bool Qbutton4 = butQ4.GetComponent<ButtonScript>().pressed;
        bool Qbutton5 = butQ5.GetComponent<ButtonScript>().pressed;

        if (Qbutton1 && Qbutton2 && Qbutton3 && Qbutton4 && Qbutton5)
        {
            if (craneBuilt)
            {
                gameWin = true;
                Debug.Log("YAAAAAAAAAAAAAAAAY");
            }
        }

    }

    public void Bags()
    {
        if (redBearFree)
        {
            tabSign.SetActive(true);
        }

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
            bag5.SetActive(true);
        }
        else
        {
            bag1.SetActive(false);
            bag2.SetActive(false);
            bag3.SetActive(false);
            bag4.SetActive(false);
            bag5.SetActive(false);
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
            puzz1Bear.SetActive(false);
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
        if (puzz3B1 && !b1trig)
        {
            powPar1.Play();
            puzz3Powder1.SetActive(true);
            sugarFall.Play();
            b1trig = true;
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
        if (puzz3B3 && !b3trig)
        {
            if (powderCount2 == 0)
            {
                powPar2.Play();
                puzz3Powder2.SetActive(true);
                sugarFall.Play();
                powderCount2 += 1;
            }
            else if (powderCount2 == 1)
            {
                powPar2.Play();
                puzz3Powder3.SetActive(true);
                sugarFall.Play();
            }
            b3trig = true;

        }
        if (puzz3B4 && !b4trig)
        {
            if (powderCount2 == 0)
            {
                powPar2.Play();
                puzz3Powder2.SetActive(true);
                sugarFall.Play();
                powderCount2 += 1;
            }
            else if (powderCount2 == 1)
            {
                powPar2.Play();
                puzz3Powder3.SetActive(true);
                sugarFall.Play();
            }
            b4trig = true;
        }

        //Part 3
        if (puzz3B5 && !b5trig)
        {
            if (powderCount3 == 0)
            {
                powPar3.Play();
                puzz3Powder4.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 1)
            {
                powPar3.Play();
                puzz3Powder5.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 2)
            {
                powPar3.Play();
                puzz3Powder6.SetActive(true);
                sugarFall.Play();
            }
            b5trig = true;
        }
        if (puzz3B6 && !b6trig)
        {
            if (powderCount3 == 0)
            {
                powPar3.Play();
                puzz3Powder4.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 1)
            {
                powPar3.Play();
                puzz3Powder5.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 2)
            {
                powPar3.Play();
                puzz3Powder6.SetActive(true);
                sugarFall.Play();
            }
            b6trig = true;
        }
        if (puzz3B7 && !b7trig)
        {
            if (powderCount3 == 0)
            {
                powPar3.Play();
                puzz3Powder4.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 1)
            {
                powPar3.Play();
                puzz3Powder5.SetActive(true);
                sugarFall.Play();
                powderCount3 += 1;

            }
            else if (powderCount3 == 2)
            {
                powPar3.Play();
                puzz3Powder6.SetActive(true);
                sugarFall.Play();
            }
            b7trig = true;
        }
    }
}
