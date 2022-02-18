using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{

    protected Joystick joystick;
    protected JumpButton jumpButton;

    protected bool jump;
    protected bool isGrounded;
    public float moveSpeed;
    private int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        jumpButton = FindObjectOfType<JumpButton>();
        coinCount = 0;
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal"), rb.velocity.y, joystick.Vertical * moveSpeed + Input.GetAxis("Vertical"));
       //note you will need the above line for level one to work correctly

        //rb.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal"), rb.velocity.y, moveSpeed + Input.GetAxis("Vertical"));

        if (!jump && isGrounded && (jumpButton.pressed || Input.GetKeyDown(KeyCode.Space)))
        {
            jump = true;
            rb.velocity += Vector3.up * 10f;
            isGrounded = false;
        }
        if (jump && (!jumpButton.pressed || Input.GetButton("Fire2")) )
        {
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "trampoline")
        {
            var rb = GetComponent<Rigidbody>();
            rb.velocity += Vector3.up * 5f;
        }
        else if(collision.gameObject.tag == "speedBoost")
        {
            Debug.Log("boosting");
            moveSpeed = 30f;
        }
        //Debug.Log("colliding");
        //if(collision.gameObject.tag == "floor")
        // {
        else
        {
           //moveSpeed = 10f;
        }
        isGrounded = true;
       // }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            coinCount++;
        }
    }
}
