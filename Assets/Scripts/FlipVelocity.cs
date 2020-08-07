using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipVelocity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        print(collision.tag);
        // Flips the velocity
        if (collision.CompareTag("Ball")) {
            collision.GetComponent<Rigidbody2D>().velocity *= (Vector3.right * -1);
        }
    }
}