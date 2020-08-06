using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour {
    public InputMaster controls;

    public float rotationAngle = 45f;
    [Range(0f, 2f)]
    public float timeToRotate = 1f;

    void Awake() {
        controls = new InputMaster();
    }

    void Update() {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        if(mouse.leftButton.wasPressedThisFrame) {
            Debug.Log("Mouse pressed");
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
            Debug.Log("Mouse released");
            RotateDown();
        }
    }

    void RotateUp() {
        LeanTween.rotate(gameObject, new Vector3(
            transform.rotation.x, transform.rotation.y, rotationAngle
        ), timeToRotate);
    }

    void RotateDown() {
        LeanTween.rotate(gameObject, new Vector3(
            transform.rotation.x, transform.rotation.y, 0
        ), timeToRotate);
    }
}
