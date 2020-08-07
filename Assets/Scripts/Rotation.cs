using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour {
    public float rotationAngle = 45f;
    [Range(0f, 2f)]
    public float rotationTime = 1f;
    private bool rotating = false;
    private bool rotated = false;

    void Update() {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        if(mouse.leftButton.wasPressedThisFrame) {
            if (rotating)
                return;

            var mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            mousePosition.z = 0f;
            if(GetComponent<BoxCollider2D>().bounds.Contains(mousePosition)) {
                if (rotated)
                    RotateDown();
                else
                    RotateUp();
            }
        }
    }

    void RotateUp() {
        rotating = true;
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, rotationAngle), rotationTime).setOnComplete(() => {
            rotating = false;
            rotated = true;
        });
    }

    void RotateDown() {
        rotating = true;
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, 0f), rotationTime).setOnComplete(() => {
            rotating = false;
            rotated = false;
        });
    }
}
