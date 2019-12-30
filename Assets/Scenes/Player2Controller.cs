using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public Animator anim;
    public float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") * walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            move *= 2f; //spring multiplier
        }
        anim.SetFloat("Speed", move);
    }
}
