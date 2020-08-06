using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controls : MonoBehaviour
{
    public GameObject ball;
    public float startSpeed = 1f;

    private Transform startingBallTransform;

    void Start() {
        startingBallTransform = ball.transform;
        ball.GetComponent<Rigidbody>().velocity = startSpeed * Vector3.right;
    }

    void Reset() {
        ball.transform.position = startingBallTransform.position;
        ball.transform.rotation = startingBallTransform.rotation;
    }
}
