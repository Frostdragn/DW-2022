using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private SpriteRenderer _sprite;
    public Animator _anim;

    bool landSoundPlayed;
    public AudioSource audioData;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip jump3;
    public AudioClip jump4;
    public AudioClip land1;
    public AudioClip land2;
    public AudioClip land3;
    int soundRandom;

    public GameObject indicator;
    public GameObject stickyIn;
    public GameObject bearBag;

    public GameObject groundCheck;

    public static bool tutorSolved;
    public static bool tutorClear;

    public static bool powderSolved;

    public int speed = 10;
    private float moving;
    private float jumping;
    private bool faceRight;
    private bool faceLeft;

    public int jumpHeight = 500;
    public bool grounded;
    public static bool grouped;

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
        bearBag.SetActive(false);
        grouped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject == ChosenGummy.chosenPlayer && Input.GetKeyDown(KeyCode.Tab) && grouped)
        {
            grouped = false;
        }

        if (grouped)
        {        
            if (this.gameObject != ChosenGummy.chosenPlayer)
            {
                sticky = false;
                stickyIn.SetActive(false);
                _body.constraints = RigidbodyConstraints2D.FreezeAll;
                _box.enabled = false;
                this.gameObject.transform.position = new Vector3(ChosenGummy.chosenPlayer.transform.position.x, ChosenGummy.chosenPlayer.transform.position.y + 2, ChosenGummy.chosenPlayer.transform.position.z);

            }
            else
            {
                bearBag.SetActive(true);
            }
        }
        else
        {
            bearBag.SetActive(false);
            _box.enabled = true;
        }

        if (this.gameObject == ChosenGummy.chosenPlayer)
        {
            Movement();

            if (faceLeft)
            {
                //transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (faceRight)
            {
                //transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetMouseButtonDown(1) && !sticky)
            {
                sticky = true;
            }
            else if (Input.GetMouseButtonDown(1) && sticky)
            {
                sticky = false;
                _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }

            if (sticky)
            {
                inputs = false;
                stickyIn.SetActive(true);
            }
            else
            {
                stickyIn.SetActive(false);
                _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }

            if (inputs)
            {
                _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }

            if (this.gameObject.transform.position.x < -58 && this.gameObject.transform.position.y > 26)
            {
                powderSolved = true;
            }

            indicator.SetActive(true);

        }
        else
        {
            indicator.SetActive(false);
            _anim.SetBool("Walking", false);
        }
    }

    public void Movement()
    {
        moving = _body.velocity.x;
        jumping = _body.velocity.y;

        if (moving > 0.5f || moving < -0.5f)
        {
            _anim.SetBool("Walking", true);
        }
        else
        {
            _anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown("d"))
        {
            faceRight = true;
            faceLeft = false;
        }
        if (Input.GetKeyUp("d") && Input.GetKey("a"))
        {
            faceRight = false;
            faceLeft = true;
        }
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

        if (Input.GetKeyDown("a"))
        {
            faceRight = false;
            faceLeft = true;
        }
        if (Input.GetKeyUp("a") && Input.GetKey("d"))
        {
            faceRight = true;
            faceLeft = false;
        }
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
            landSoundPlayed = false;
            if (!sticky)
            {
                soundRandom = Random.Range(0, 3);
                if (soundRandom == 0)
                {
                    audioData.clip = jump1;
                }
                else if (soundRandom == 1)
                {
                    audioData.clip = jump2;
                }
                else if (soundRandom == 2)
                {
                    audioData.clip = jump3;
                }
                else
                {
                    audioData.clip = jump4;
                }
                    audioData.Play();
            }
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
            //grounded = true;

            if (landSoundPlayed == false)
            {
                soundRandom = Random.Range(0, 2);
                if (soundRandom == 0)
                {
                    audioData.clip = land1;
                }
                else if (soundRandom == 1)
                {
                    audioData.clip = land2;
                }
                else
                {
                    audioData.clip = land3;
                }
                audioData.Play();
                landSoundPlayed = true;
            }
            

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
        if (collision.gameObject.layer == 8)
        {
            grounded = false;
            _body.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
