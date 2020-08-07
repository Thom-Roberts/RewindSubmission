using UnityEngine;

public class Goal : MonoBehaviour {
    public bool active = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball") && active) {
            // Likely do a slow down effect or something
            print("Success! Time to move on to the next level.");
        }
    }
}
