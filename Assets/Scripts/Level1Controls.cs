using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Controls : MonoBehaviour
{
    public GameObject ball;
    public float startSpeed = 4f;
    public TextMeshProUGUI tutorialText;
    public float timeToHide = 2.5f;
    
    private Transform startingBallTransform;

    void Start() {
        startingBallTransform = ball.transform;
        ball.GetComponent<Rigidbody2D>().velocity = startSpeed * Vector3.right;
        tutorialText.GetComponent<CanvasGroup>().LeanAlpha(1f, 0.5f);
        StartCoroutine(hideTutorialText());
    }

    void Reset() {
        ball.transform.position = startingBallTransform.position;
        ball.transform.rotation = startingBallTransform.rotation;
    }

    IEnumerator hideTutorialText() {
        yield return new WaitForSeconds(timeToHide);
        tutorialText.GetComponent<CanvasGroup>().LeanAlpha(0f, timeToHide);
    }
}
