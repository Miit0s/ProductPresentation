using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int destination = 0;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Si arrive entre ces deux coordonné, le sprite change de destination
        if (transform.position.x < originalPosition.x - 50 && transform.position.x > originalPosition.x - 55)
        {
            destination = 1;
        }
        else if (transform.position.x < originalPosition.x + 55 && transform.position.x > originalPosition.x + 50)
        {
            destination = 0;
        }


        //Si la destination est égal à 0, le sprite va à gauche et sinon il va à droite
        if (destination == 0)
        {
            transform.position += new Vector3(-0.8f, 0, 0);
        }
        else if (destination == 1)
        {
            transform.position += new Vector3(0.8f, 0, 0);
        }
    }
}
