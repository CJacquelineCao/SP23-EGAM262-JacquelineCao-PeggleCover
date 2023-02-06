using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int ballsRemaining = 10;
    public BallTransform balls;
    public Transform ballspawn;
    public GameObject ballBar;
    public bool balldestroyed;


    ScoreCounter scoreref;

    public GameObject normalholes;
    public GameObject fullholes;

    public GameObject bucket;
    public GameObject destroyzone;

    public bool endcalled;
    public GameObject EndScreen;
    public TMP_Text State;
    public TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
        ballBar = GameObject.FindGameObjectWithTag("Bar").gameObject;
        scoreref = gameObject.GetComponent<ScoreCounter>();
        bucket = GameObject.Find("BallBucket");
        destroyzone = GameObject.Find("DestroyZone");

    }

    // Update is called once per frame

    private void Update()
    {
        if (ballsRemaining == 0)
        {
            if (scoreref.orangePegsCount == 0)
            {
                if (endcalled == false)
                {
                    scoreref.tallyTotal();
                    onGameWin();
                    endcalled = true;
                }

            }

        }
        if (scoreref.orangePegsCount == 0)
        {

            if (endcalled == false)
            {
                scoreref.tallyTotal();
                onGameWin();
                endcalled = true;
            }
        }
    }




    public void addballs()
    {
        BallTransform newball = GameObject.Instantiate<BallTransform>(balls);
        newball.transform.position = ballspawn.position;
        newball.transform.parent = ballBar.transform;
        ballsRemaining += 1;
    }
    public void removeballs()
    {
        GameObject recball = ballBar.transform.GetChild(1).gameObject;
        Destroy(recball);
        balldestroyed = true;
        ballsRemaining -= 1;
    }

    public void onGameWin()
    {
        bucket.SetActive(false);
        destroyzone.SetActive(false);
        if(ballsRemaining >0)
        {
            scoreref.ExtraBall(ballsRemaining);
            foreach (Transform ball in ballBar.transform)
            {
                Destroy(ball.gameObject);
            }
            ballsRemaining = 0;
        }
        if (scoreref.bluePegsCount ==0)
        {
           GameObject fullhole = GameObject.Instantiate(fullholes);
        }
        else
        {
            GameObject halfhole = GameObject.Instantiate(normalholes);
        }
    }
    public void showfinalScreen()
    {
        EndScreen.SetActive(true);
        State.text = "You win!";
        Score.text = "Final Score: " + scoreref.finalScore;
        Time.timeScale = 0;

    }
    public void onGameLose()
    {
        bucket.SetActive(false);
        EndScreen.SetActive(true);
        State.text = "Game Over";
        Score.text = "Final Score: " + scoreref.finalScore;
        Time.timeScale = 0;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}





