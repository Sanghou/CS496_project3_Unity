using UnityEngine;

public class Character : MonoBehaviour {

    public enum playerState
    {
        normal = 0,
        run,
        jump
    }

    public bool isRight;

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
    public Inventory inventory;
    public bool hasItem = false;

    public AudioSource jumpAudio;

    public int clickCount;
    
    void Start() {
        theRB = GetComponent<Rigidbody>();

        isRight = true;
        state = playerState.normal;
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed=0, zSpeed=0;

        bool jumpKeyDown = false;

        if (Input.GetKey(leftKey)) {
            xSpeed = -moveSpeed;
            isRight = false;
        } else if (Input.GetKey(rightKey)){
            xSpeed = moveSpeed;
            isRight = true;
        }

        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey(frontKey)){
            zSpeed = -moveSpeed;
        }
        else if (Input.GetKey(backKey)){
            zSpeed = moveSpeed;
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            jumpAudio.Play();
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

        if (Input.GetKeyDown(pickup) && currentItem && !hasItem)
        {
            if (clickCount > 1)
            {
                clickCount--;
            }
            else
            {
                GetItem(currentItem);
            }
        }
        else if (Input.GetKeyDown(pickup) && hasItem)
        {
            UseItem();
        }
    }

    private void OnTriggerEnter(Collider item)
    {
        //print(other.tag);
        if (item.CompareTag("item"))
        {
            currentItem = item.gameObject;
            clickCount = 1;
        } else if (item.CompareTag("Key"))
        {
            currentItem = item.gameObject;
            clickCount = 5;
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

    public void UseItem()
    {
        Debug.Log("UseItem");
        currentItem.transform.position = transform.position;
        currentItem.GetComponent<Item>().useEvent.Invoke();
        inventory.UseItem(currentItem);
        hasItem = false;
        currentItem = null;
    }

    public void GetItem(GameObject item)
    {
        currentItem = item;
        Debug.Log("GetItem");
        hasItem = true;
        inventory.AddItem(currentItem);
        currentItem.GetComponent<Item>().pickEvent.Invoke();
    }
}
