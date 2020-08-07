using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHatch : MonoBehaviour
{
    public GameObject rotater;
    public float depressDistance = 0.21f;
    public float rotationAngle = 135f;
    public float rotationTime = 0.5f;
    private bool pressed = false;
    private bool rotating = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ball") && !rotating) {
            rotating = true;
            pressButton();

            if (pressed)
                rotateDown();
            else
                rotateUp();
        }
    }

    private void pressButton() {
        LeanTween.moveLocalY(gameObject, transform.position.y - depressDistance, rotationTime).setOnComplete(() => {
            LeanTween.moveLocalY(gameObject, transform.position.y + depressDistance, rotationTime);
        });
    }

    private void rotateUp() {
        rotating = true;
        LeanTween.rotate(rotater, new Vector3(transform.rotation.x, transform.rotation.y, rotationAngle), rotationTime).setOnComplete(() => {
            pressed = true;
            rotating = false;
        });
    }

    private void rotateDown() {
        rotating = true;
        LeanTween.rotate(rotater, new Vector3(transform.rotation.x, transform.rotation.y, 0f), rotationTime).setOnComplete(() => {
            pressed = true;
            rotating = false;
        });
    }
}
