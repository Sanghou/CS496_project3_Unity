using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

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
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody>();

        whatIsGround = 1 << LayerMask.NameToLayer("Ground");
        state = playerState.normal;
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = 0, zSpeed = 0;

        bool jumpKeyDown = false;

        if (Input.GetKey("left"))
        {
            xSpeed = -moveSpeed;
        }
        else if (Input.GetKey("right"))
        {
            xSpeed = moveSpeed;
        }

        if (Input.GetKey("down"))
        {
            zSpeed = -moveSpeed;
        }
        else if (Input.GetKey("up"))
        {
            zSpeed = moveSpeed;
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            theRB.velocity = new Vector3(xSpeed, jumpForce, zSpeed);
            jumpKeyDown = true;
        }
        else
        {
            theRB.velocity = new Vector3(xSpeed, theRB.velocity.y, zSpeed);
        }


        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1), 3f, whatIsGround);


        if (isGrounded)
        {
            if (theRB.velocity.x == 0 && theRB.velocity.z == 0)
                state = playerState.normal;
            else
                state = playerState.run;

            if (jumpKeyDown)
                state = playerState.jump;
        }
        else
        {
            state = playerState.jump;
        }

        if (anim != null)
        {
            anim.SetInteger("playerState", (int)state);
        }
    }
}