using UnityEngine;

public class FirstButtonController : MonoBehaviour
{
    public GameObject ball;
    public float startSpeed = 4f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() {
        rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * startSpeed;
    }

    private void LateUpdate() {
        rb.velocity = startSpeed * (rb.velocity.normalized);
    }
}
