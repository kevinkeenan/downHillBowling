using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public GameObject sizeUp;
    public GameObject speedUp;
    public GameObject player;
    public bool isBigger;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isBigger = false;
        rb = GetComponent<Rigidbody>();
        //StartCoroutine(delay());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sizeUp")
        {
            sizeUp.SetActive(false);
            other.gameObject.SetActive(false);
            player.gameObject.transform.localScale += new Vector3(.5f, .5f, .5f);
            StartCoroutine(delay());
            isBigger = true;
        }
        else if (other.tag == "coin")
        {
            other.gameObject.SetActive(false);
        }
    }


    /*
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "sizeUp")
        {
            sizeUp.SetActive(false);
            player.gameObject.transform.localScale += new Vector3(.5f, .5f, .5f);
            StartCoroutine(delay());
            isBigger = true;
        }
        else if(other.collider.tag == "speedUp")
        {
            speedUp.SetActive(false);
            StartCoroutine(speedUpMethod());
        }
    }
    */

    public void shrink()
    {
        player.gameObject.transform.localScale -= new Vector3(.5f, .5f, .5f);
    }
    

    IEnumerator delay()
    {
        //This is a coroutine
        Debug.Log("before");

        yield return new WaitForSeconds(5);    //Wait one frame

        Debug.Log("after");
        shrink();
        isBigger = false;
    }

    IEnumerator speedUpMethod()
    {
        //This is a coroutine
        Debug.Log("beforeSpeed");
        rb.AddForce(Vector3.forward * 300f);

        yield return new WaitForSeconds(3);    //Wait one frame

        Debug.Log("afterSpeed");
       // shrink();
        //isBigger = false;
    }
}
