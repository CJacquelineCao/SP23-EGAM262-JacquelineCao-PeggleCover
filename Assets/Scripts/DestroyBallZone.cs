using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallZone : MonoBehaviour
{
    ScoreCounter scoreref;
    GameController mainref;
    // Start is called before the first frame update
    private void Start()
    {
        scoreref = GameObject.Find("GameController").GetComponent<ScoreCounter>();
        mainref = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            BallTransform ball = collision.gameObject.GetComponent<BallTransform>();
            ball.destroyBall();
            scoreref.tallyTotal();

            if (mainref.ballsRemaining == 0)
            {
                if (scoreref.orangePegsCount > 0)
                {
                    if (mainref.endcalled == false)
                    {
                        scoreref.tallyTotal();
                        mainref.onGameLose();
                        mainref.endcalled = true;
                    }

                }
            }

        }
    }
}
