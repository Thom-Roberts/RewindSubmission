using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            // Likely do a slow down effect or something
            print("Success! Time to move on to the next level.");
        }
    }
}
