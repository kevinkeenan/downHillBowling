using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isKnockedOverScript : MonoBehaviour
{
    public GameObject pin;

    public bool isKnocked;
    //public Transform position;


    /*
     * After the player passes through a certain point, update the score
     * add to score for every pin if isKnocked = true
     * helper method to update the score if it is a strike
     *
     * need to make 10 zones that are triggers
     * not sure if it is possible for is knocked to become false after it is changed to true
     * add the canvas gameObject
     *

     */

    // Start is called before the first frame update
    void Start()
    {
        isKnocked = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Quaternion newRotation = pin.gameObject.transform.rotation;
        //Debug.Log(newRotation);
        //Debug.Log("Z pos: " + newRotation.z);
        //TAKE THE abs val of the rotation of the pin and return a bool
    }

    void Update()
    {
        Vector3 pinPosition = pin.gameObject.transform.position;


        if (Mathf.Abs(pinPosition.y) < .5)
        {
            isKnocked = true;
            //Debug.Log(isKnocked);
        }
    }
}
