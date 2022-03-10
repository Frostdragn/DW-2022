using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBears : MonoBehaviour
{

    public int color;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Color", color);
    }
}
