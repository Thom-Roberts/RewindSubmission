using UnityEngine;

public class Goal : MonoBehaviour {
    public bool active = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball") && active) {
            // Likely do a slow down effect or something
            print("Success! Time to move on to the next level.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var temp = collision.collider;
        if(temp.CompareTag("Ball")) {
            if (temp.GetComponent<Rewind>().rewinding)
                return;
            print("Success! Time to move on to the next level.");
        }
    }
}
