using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private SpriteRenderer _sprite;

    public GameObject indicator;
    public GameObject stickyIn;

    public int speed = 10;
    private float moving;
    private float jumping;
    //private bool faceRight;
    //private bool faceLeft;

    public int jumpHeight = 500;
    public bool grounded;
    public bool grouped;

    public bool reselected;
    private bool sticky;
    private bool inputs;
    private bool floating;

    public static Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        indicator.SetActive(false);
        stickyIn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !grouped)
        {
            grouped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && grouped)
        {
            grouped = false;
        }

        if (grouped)
        {
            if (this.gameObject != ChosenGummy.chosenPlayer)
            {
                sticky = false;
                _body.constraints = RigidbodyConstraints2D.FreezeAll;
                _box.enabled = false;
                this.gameObject.transform.position = new Vector3(ChosenGummy.chosenPlayer.transform.position.x, ChosenGummy.chosenPlayer.transform.position.y + 2, ChosenGummy.chosenPlayer.transform.position.z);
            }
        }
        else
        {
            _box.enabled = true;
        }

        if (this.gameObject == ChosenGummy.chosenPlayer)
        {
            Movement();
            if (Input.GetMouseButtonDown(1) && !sticky)
            {
                sticky = true;
                //_body.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else if (Input.GetMouseButtonDown(1) && sticky)
            {
                sticky = false;
                stickyIn.SetActive(false);
            }

            if (sticky)
            {
                inputs = false;
                stickyIn.SetActive(true);
            }

            if (inputs)
            {
                _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }

            indicator.SetActive(true);

        }
        else
        {
            indicator.SetActive(false);
        }
    }

    public void Movement()
    {
        moving = _body.velocity.x;
        jumping = _body.velocity.y;

        //if (Input.GetKeyDown("d"))
        //{
        //    faceRight = true;
        //    faceLeft = false;
        //}
        //if (Input.GetKeyUp("d") && Input.GetKey("a"))
        //{
        //    faceRight = false;
        //    faceLeft = true;
        //}
        if (Input.GetKey("d"))
        {
            inputs = true;
            //sticky = false;
            _body.velocity = new Vector2(speed, jumping);
        }
        else if (Input.GetKeyUp("d") && !Input.GetKey("a"))
        {
            inputs = true;
            //sticky = false;
            _body.velocity = new Vector2((moving / 2), jumping);
        }

        //if (Input.GetKeyDown("a"))
        //{
        //    faceRight = false;
        //    faceLeft = true;
        //}
        //if (Input.GetKeyUp("a") && Input.GetKey("d"))
        //{
        //    faceRight = true;
        //    faceLeft = false;
        //}
        if (Input.GetKey("a"))
        {
            inputs = true;
            //sticky = false;
            _body.velocity = new Vector2(-speed, jumping);
        }
        else if (Input.GetKeyUp("a") && !Input.GetKey("d"))
        {
            inputs = true;
            _body.velocity = new Vector2((moving / 2), jumping);
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            inputs = true;
            //sticky = false;
            _body.velocity = new Vector2(moving, 0);
            _body.AddForce(Vector2.up * jumpHeight);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            grounded = true;

            if (this.gameObject != ChosenGummy.chosenPlayer)
            {
                if (sticky)
                {
                    _body.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }

            if (this.gameObject == ChosenGummy.chosenPlayer)
            {
                if (sticky)
                {
                    _body.constraints = RigidbodyConstraints2D.FreezeAll;

                }
                else
                {
                    _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }
                
            }
        }

        if (collision.gameObject.layer == 8)
        {
            if (this.gameObject != ChosenGummy.chosenPlayer)
            {
                if (sticky)
                {
                    _body.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }

            if (this.gameObject == ChosenGummy.chosenPlayer)
            {
                if (sticky)
                {
                    _body.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                else
                {
                    _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            grounded = false;
            _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
