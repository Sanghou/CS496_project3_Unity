using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode front;
    public KeyCode back;
    public KeyCode jump;
    public KeyCode pickup;

    private Rigidbody theRB;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    public GameObject currentItem = null;
    public Item currentItemScript = null;
    public Inventory inventory;
    public bool isthereItem = false;



    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector3(-moveSpeed, theRB.velocity.y, 0);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector3(moveSpeed, theRB.velocity.y, 0);
        }
        else if (Input.GetKey(front))
        {
            theRB.velocity = new Vector3(0, theRB.velocity.y, moveSpeed);
        }
        else if (Input.GetKey(back))
        {
            theRB.velocity = new Vector3(0, theRB.velocity.y, -moveSpeed);
        }
        else
        {
            theRB.velocity = new Vector3(0, theRB.velocity.y, 0);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, 0);
        }

        if(Input.GetKeyDown(pickup) && currentItem && !isthereItem)
        {
            if (currentItemScript.inventory)
            {
                inventory.AddItem(currentItem);
                isthereItem = true;
                currentItem.SendMessage("DoInteraction");
            }
        }else if(Input.GetKeyDown(pickup) && isthereItem)
        {
            currentItem.transform.position = GameObject.Find("Player1").transform.position;
            currentItem.SetActive(true);
            inventory.UseItem(currentItem);
            isthereItem = false;
            
        }
        
        //anim.SetFloat("Speed", theRB.velocity.x);
        //anim.SetBool("Grounded", isGrounded);

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
            print("Trigger exit");
            if(item.gameObject == currentItem)
            {
                currentItem = null;
            }
        }
    }

}

