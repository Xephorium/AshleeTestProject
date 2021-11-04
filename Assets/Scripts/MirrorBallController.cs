using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBallController : MonoBehaviour {


    /*--- Variables ---*/

    public GameObject sourceBall;


    /*--- Methods ---*/

    // Called On A Fixed Interval
    void Update() {

        transform.position = new Vector3(
            sourceBall.transform.position.x,
            sourceBall.transform.position.y,
            -sourceBall.transform.position.z
            );
    }
}
