using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject cheese;

    private Vector3 cheesePos;

    public ParticleSystem mousePoof;

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
            Instantiate(mousePoof, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
