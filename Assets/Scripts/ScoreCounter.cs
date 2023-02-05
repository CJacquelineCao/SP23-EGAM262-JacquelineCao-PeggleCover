using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    int blueBaseScore = 10;
    int orangeBaseScore = 100;
    int blueScore;
    int orangeScore;

    int totalBallsHit;
    public int finalScore;
    int fevermulti = 1;

    public int bluePegsCount;
    public int orangePegsCount;

    public List<Peg> pegList;

    public Slider fevermeter;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + finalScore;

        if(orangePegsCount == 0)
        {
            fevermulti = 100;
        }
        else if(orangePegsCount < 3)
        {
            fevermulti = 10;
        }
        else if(orangePegsCount< 6)
        {
            fevermulti = 5;
        }
        else if(orangePegsCount < 10)
        {
            fevermulti = 3;
        }
        else if (orangePegsCount < 15)
        {
            fevermulti = 2;
        }
    }
    public void addBlueScore()
    {
        blueScore = blueBaseScore * fevermulti;
        bluePegsCount -= 1;
        totalBallsHit += 1;
    }
    public void addOrangeScore()
    {
        orangeScore = orangeBaseScore * fevermulti;
        orangePegsCount -= 1;
        fevermeter.value += 0.04f;
        totalBallsHit += 1;
    }

    public void tallyTotal()
    {
        finalScore += totalBallsHit * (blueScore + orangeScore);
        totalBallsHit = 0;

        foreach (Peg orb in GameObject.FindObjectsOfType<Peg>())
        {
            pegList.Add(orb);
            if (pegList.Count > 0)
            {
                orb.DestroyafterCollision();
                
            }

        }
        pegList.Clear();

    }
}
