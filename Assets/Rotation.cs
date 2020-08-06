using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour {
    public float rotationAngle = 45f;
    [Range(0f, 2f)]
    public float rotationTime = 1f;

    private bool rotating = false;

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

        /*if(rotating) {
            Vector3 to = transform.rotation.eulerAngles;
            to.z = rotationAngle;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        }*/
    }

    void RotateUp() {
        rotating = true;
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, rotationAngle), rotationTime);
        /*
        LeanTween.value(gameObject, (val) => {
            transform.Rotate(transform.rotation.x, transform.rotation.y, val);
        }, transform.rotation.z, rotationAngle, timeToRotate);*/
    }

    void RotateDown() {
        LeanTween.rotate(gameObject, new Vector3(transform.rotation.x, transform.rotation.y, 0f), rotationTime);
    }
}
