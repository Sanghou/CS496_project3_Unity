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
    public KeyCode pickup;

    private Rigidbody theRB;
    public LayerMask whatIsGround;
    public float groundCheckRadius;

    public bool isGrounded;

    public GameObject currentItem = null;
    public Item currentItemScript = null;
    public Inventory inventory;
    public bool isthereItem = false;
    
    void Start() {
        theRB = GetComponent<Rigidbody>();

        //whatIsGround = 1 << LayerMask.NameToLayer("Ground");
        state = playerState.normal;
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed=0, zSpeed=0;

        bool jumpKeyDown = false;

        if (Input.GetKey(leftKey)) {
            xSpeed = -moveSpeed;
        } else if (Input.GetKey(rightKey)){
            xSpeed = moveSpeed;
        }

        if (Input.GetKey(frontKey)){
            zSpeed = -moveSpeed;
        }
        else if (Input.GetKey(backKey)){
            zSpeed = moveSpeed;
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector3(xSpeed, jumpForce, zSpeed);
            jumpKeyDown = true;
        }
        else
        {
            theRB.velocity = new Vector3(xSpeed, theRB.velocity.y, zSpeed);
        }


        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1), groundCheckRadius, whatIsGround);
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

        if (Input.GetKeyDown(pickup) && currentItem && !isthereItem)
        {
            if (currentItemScript.inventory)
            {
                inventory.AddItem(currentItem);
                isthereItem = true;
                currentItem.SendMessage("DoInteraction");
            }
        }
        else if (Input.GetKeyDown(pickup) && isthereItem)
        {
            currentItem.transform.position = GameObject.Find("Player2").transform.position;
            currentItem.SetActive(true);
            inventory.UseItem(currentItem);
            isthereItem = false;

        }
    }

    private void OnTriggerEnter(Collider item)
    {
        //print(other.tag);
        if (item.CompareTag("item"))
        {
            currentItem = item.gameObject;
            currentItemScript = currentItem.GetComponent<Item>();
        }

    }

    private void OnTriggerExit(Collider item)
    {
        if (item.CompareTag("item"))
        {
            if (item.gameObject == currentItem)
            {
                currentItem = null;
            }
        }
    }
}
