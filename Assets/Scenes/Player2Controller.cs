using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public Animator anim;
    public float walkSpeed;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Normalize();
        movement *= walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            movement *= 2f; //sprint multiplier
        }

        speed = movement.magnitude;
        anim.SetFloat("Speed", speed);
        anim.SetFloat("VelocityX", movement.x);
        anim.SetFloat("VelocityZ", movement.y);
    }
}
