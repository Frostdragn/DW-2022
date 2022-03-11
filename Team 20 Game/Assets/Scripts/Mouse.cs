using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject cheese;

    private Vector3 cheesePos;

    void Start()
    {
        cheesePos = cheese.transform.position;
    }

    void Update()
    {
        if (cheese.transform.position.y < 2)
        {
            cheese.transform.position = cheesePos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionCheck = collision.gameObject;

        if (collision.tag == "Cheese")
        {
            cheese.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
