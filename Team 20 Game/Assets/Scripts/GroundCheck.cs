using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;
        Player parentScript = transform.parent.GetComponent<Player>();

        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            parentScript.grounded = true;
        }

    }
}
