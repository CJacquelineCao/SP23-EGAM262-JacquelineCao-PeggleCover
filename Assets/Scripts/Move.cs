using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform nozzle;
    public BallTransform BallPrefab;
    public Transform Spawnpoint;
    public SpriteRenderer ballsprite;
    public bool ballLaunched;
    public GameController contref;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void FixedUpdate()
    {
        Vector2 nozdir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - nozzle.position).normalized;
        nozzle.GetComponent<Rigidbody2D>().rotation = BallTransform.GetAngleFromVectorFloat(nozdir);
    }
    private void Update()
    {
        if (ballLaunched == false)
        {
            if(contref.ballsRemaining >0)
            {
                ballsprite.enabled = true;
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("launch");
                    contref.removeballs();
                    BallTransform newball = GameObject.Instantiate<BallTransform>(BallPrefab);
                    newball.transform.position = Spawnpoint.position;
                    newball.transform.rotation = Spawnpoint.rotation;
                    newball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    newball.Launch(10);
                    ballLaunched = true;
                    if (ballsprite.enabled == true)
                    {
                        ballsprite.enabled = false;
                    }
                }
            }

        }
   
    }
}
