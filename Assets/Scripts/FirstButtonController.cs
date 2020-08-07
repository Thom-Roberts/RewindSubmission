using UnityEngine;

public class FirstButtonController : MonoBehaviour
{
    public GameObject ball;
    public float startSpeed = 4f;

    // Start is called before the first frame update
    void Start() {
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.right * startSpeed;
    }
}
