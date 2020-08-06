using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Controls : MonoBehaviour
{
    public GameObject ball;
    public float startSpeed = 1f;
    public TextMeshProUGUI tutorialText;
    public float timeToHide = 2f;
    
    private Transform startingBallTransform;

    void Start() {
        startingBallTransform = ball.transform;
        ball.GetComponent<Rigidbody>().velocity = startSpeed * Vector3.right;

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
