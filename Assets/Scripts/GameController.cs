using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int ballsRemaining = 10;
    public BallTransform balls;
    public Transform ballspawn;
    public GameObject ballBar;
    public bool balldestroyed;
    // Start is called before the first frame update
    void Start()
    {
        ballBar = GameObject.FindGameObjectWithTag("Bar").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
  
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
}
