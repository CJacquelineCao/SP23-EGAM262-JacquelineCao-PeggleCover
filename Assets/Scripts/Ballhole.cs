using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballhole : MonoBehaviour
{
    ScoreCounter scoreref;
    GameController mainref;
    // Start is called before the first frame update
    void Start()
    {
        scoreref = GameObject.Find("GameController").GetComponent<ScoreCounter>();
        mainref = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            BallTransform ball = collision.gameObject.GetComponent<BallTransform>();
            ball.destroyBall();
            mainref.addballs();
            scoreref.tallyTotal();
            print(scoreref.finalScore);
        }
    }
}
