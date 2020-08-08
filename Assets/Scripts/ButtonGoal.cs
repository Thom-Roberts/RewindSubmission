using UnityEngine;

public class ButtonGoal : MonoBehaviour {
    public SpriteRenderer goalRenderer;
    public float alphaScalar = 1.2f;
    public float scaleTime = 0.3f;
    public float depressDistance = 0.21f;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball") && !triggered) {
            triggered = true;

            ActivateGoal();
            DepressButton();
        }
    }

    private void ActivateGoal() {
        var currentColor = goalRenderer.color;
        var targetAlpha = Mathf.Clamp(currentColor.a * alphaScalar, 0, 1);

        LeanTween.value(gameObject, val => {
            var color = goalRenderer.color;
            color.a = val;
            goalRenderer.color = color;
        }, currentColor.a, targetAlpha, scaleTime);

        goalRenderer.GetComponent<Goal>().active = true;
        goalRenderer.GetComponent<Collider2D>().enabled = true;
    }

    private void DepressButton() {
        LeanTween.moveLocalY(gameObject, transform.position.y - depressDistance, scaleTime);
    }
}