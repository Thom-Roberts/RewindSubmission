using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform levelStart;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball")) {
            other.GetComponent<Transform>().position = levelStart.position;
        }
    }
}
