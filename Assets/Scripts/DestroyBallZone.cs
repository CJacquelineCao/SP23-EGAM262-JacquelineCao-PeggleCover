using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallZone : MonoBehaviour
{
    ScoreCounter scoreref;
    // Start is called before the first frame update
    private void Start()
    {
        scoreref = GameObject.Find("GameController").GetComponent<ScoreCounter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ball")
        {
            BallTransform ball = collision.gameObject.GetComponent<BallTransform>();
            ball.destroyBall();
            scoreref.tallyTotal();
            print(scoreref.finalScore);
        }
    }
}
