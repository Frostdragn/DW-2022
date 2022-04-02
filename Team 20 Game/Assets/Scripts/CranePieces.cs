using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranePieces : MonoBehaviour
{
    public static bool Lpiece;
    public static bool Cpiece;
    public static bool Fpiece;

    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (this.gameObject.tag == "Licorice")
        {
            if (collision.gameObject.layer == 7)
            {
                Instantiate(particles, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Lpiece = true;
                this.gameObject.SetActive(false);
            }
        }

        if (this.gameObject.tag == "cCane")
        {
            if (collision.gameObject.layer == 7)
            {
                Instantiate(particles, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Cpiece = true;
                this.gameObject.SetActive(false);
            }
        }

        if (this.gameObject.tag == "Fudge")
        {
            if (collision.gameObject.layer == 7)
            {
                Instantiate(particles, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Fpiece = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
