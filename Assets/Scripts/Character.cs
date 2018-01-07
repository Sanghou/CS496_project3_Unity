using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public enum playerState
    {
        normal = 0,
        run,
        jump
    }

    public Animator anim;
    public playerState state = playerState.normal;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode frontKey;
    public KeyCode backKey;
    public KeyCode jump;
    public KeyCode pileBlock;

    private Rigidbody theRB;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Use this for initialization
    void Start() {
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed=0, zSpeed=0;

        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1), 0.5f);
        state = playerState.normal;

        if (Input.GetKey(leftKey)) {
            xSpeed = -moveSpeed;
            state = playerState.run;
        } else if (Input.GetKey(rightKey)){
            xSpeed = moveSpeed;
            state = playerState.run;
        }

        if (Input.GetKey(frontKey))
        {
            zSpeed = -moveSpeed;
            state = playerState.run;
        }
        else if (Input.GetKey(backKey))
        {
            zSpeed = moveSpeed;
            state = playerState.run;
        }


        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector3(xSpeed, jumpForce, zSpeed);
        }
        else
        {
            theRB.velocity = new Vector3(xSpeed, theRB.velocity.y, zSpeed);
        }

        if (theRB.velocity.y != 0)
            state = playerState.jump;

        if (anim != null)
        {
            anim.SetInteger("playerState", (int)state);
        }
    }
}
