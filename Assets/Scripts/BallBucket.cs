using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBucket : MonoBehaviour
{

    public Vector3 Leftside;
    public Vector3 Rightside;

    public bool isLeft;

    public float lerpValue;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    private void Update()
    {
        MoveRoutine();
    }
    public void MoveRoutine()
    {

        lerpValue += Time.deltaTime * speed;
        if (isLeft == true)
        {
            gameObject.transform.position = Vector3.Lerp(Leftside, Rightside, lerpValue);

            if (gameObject.transform.position == Rightside)
            {
                lerpValue = 0;
                isLeft = false;
            }
        }

        if (isLeft == false)
        {
            gameObject.transform.position = Vector3.Lerp(Rightside, Leftside, lerpValue);

            if (gameObject.transform.position == Leftside)
            {
                lerpValue = 0;
                isLeft = true;


            }
        }
        
    }
}
