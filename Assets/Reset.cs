using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform levelStart;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            other.GetComponent<Transform>().position = levelStart.position;
        }
    }
}
