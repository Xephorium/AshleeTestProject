using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


    /*--- Variables ---*/

    Rigidbody myRigidbody;
    public float speed = 0.1f;
    public float forceMultiplier = 10f;
    public ParticleSystem p1;
    public ParticleSystem p2;


    /*--- Methods ---*/

    // Start is called before the first frame update
    void Start() {

        myRigidbody = GetComponent<Rigidbody>();

        p1.Stop();
        p2.Stop();
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Called on Fixed Interval
    void FixedUpdate() {

        moveTwo();
    }

    // Move Method 1 (Bad - Breaks Collision)
    void moveOne() {

        // Get Player Input
        float transformZ = Input.GetAxis("Vertical");
        float transformX = Input.GetAxis("Horizontal");

        // Move Ball
        transform.position = new Vector3(
            transform.position.x + (transformX * speed),
            transform.position.y,
            transform.position.z + (transformZ * speed)
            );
    }

    // Move Method 2 (Good - Uses Physics!)
    void moveTwo() {

        // Get Player Input
        float transformZ = Input.GetAxis("Vertical");
        float transformX = Input.GetAxis("Horizontal");
        bool fly = Input.GetButton("Jump");

        // Calculate Flight Force
        float flightForce = 0f;
        if (fly) {
            flightForce += 10f;
            p1.Play();
            p2.Play();
        } else {
            p1.Stop();
            p2.Stop();
        }

        // Apply Force
        myRigidbody.AddForce(new Vector3(
            transformX * forceMultiplier,
            flightForce,
            transformZ * forceMultiplier
            ));
    }
}
