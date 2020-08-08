using UnityEngine;

public class ButtonLift : MonoBehaviour {
    public GameObject objectToLift;
    public float depressDistance = 0.21f;
    public float executionTime = 0.5f;

    private bool pressed = false;
    private bool moving = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ball") && !moving) {
            pressButton();

            if (pressed)
                moveDown();
            else
                moveUp();

            pressed = !pressed;
        }
    }

    private void pressButton() {
        if(pressed)
            LeanTween.moveLocalY(gameObject, transform.position.y + depressDistance, executionTime);
        else 
            LeanTween.moveLocalY(gameObject, transform.position.y - depressDistance, executionTime);
    }

    private void moveUp() {
        LeanTween.moveLocalY(objectToLift, objectToLift.transform.position.y + 1, executionTime).setOnComplete(() => {
            moving = false;
        });
    }

    private void moveDown() {
        LeanTween.moveLocalY(objectToLift, objectToLift.transform.position.y - 1, executionTime).setOnComplete(() => {
            moving = false;
        });
    }
}
