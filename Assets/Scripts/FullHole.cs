using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullHole : MonoBehaviour
{
    ScoreCounter scoreref;
    GameController mainref;
    public int customscore;


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
            scoreref.addCustomScore(customscore);
            mainref.showfinalScreen();

        }
    }
}
