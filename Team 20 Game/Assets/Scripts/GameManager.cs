using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tutorButton;
    public GameObject tutorWall;

    public GameObject button2;
    public GameObject button3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pressed1 = tutorButton.GetComponent<ButtonScript>().pressed;

        if (pressed1)
        {
            tutorWall.SetActive(false);
        }
        else if (!pressed1)
        {
            tutorWall.SetActive(true);
        }
    }
}
