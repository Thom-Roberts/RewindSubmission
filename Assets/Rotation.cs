using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour {
    public float rotationAngle = 45f;
    [Range(0f, 2f)]
    public float rotationTime = 1f;

    void Update() {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        if(mouse.leftButton.wasPressedThisFrame) {
            var ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            if(Physics.Raycast(ray, out var hit)) {
                if(hit.transform.CompareTag("Rotater")) {
                    RotateUp();
                }
                else {
                    RotateDown();
                }
            }
        }
        else if(mouse.leftButton.wasReleasedThisFrame) {
            RotateDown();
        }
    }

    void RotateUp() {
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, rotationAngle), rotationTime);
    }

    void RotateDown() {
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, 0f), rotationTime);
    }
}
