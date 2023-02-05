using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTransform : MonoBehaviour
{

    public Transform ballTransform;
    public Rigidbody2D rb;
    public Collider2D collider;
    public Move moveref;
    GameController contref;
    ScoreCounter scoreref;

    // Start is called before the first frame update
    void Start()
    {
        moveref = GameObject.Find("Nozzle").GetComponent<Move>();
        contref = GameObject.Find("GameController").GetComponent<GameController>();
        scoreref = GameObject.Find("GameController").GetComponent<ScoreCounter>();
    }

    public void Launch(float force)
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        dir.Normalize();
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
        Debug.Log("direction" + dir);
        Debug.Log("force" + force);

    }
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;

    }
    public void destroyBall()
    {
        moveref.ballLaunched = false;
        Destroy(gameObject);
    }
    private void Update()
    {
        if (contref.balldestroyed == true)
        {
            StartCoroutine(waitDestroy());
            
        }
    }
    IEnumerator waitDestroy()
    {
        Debug.Log("waiting");
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.001f, transform.position.z);
        yield return new WaitForSeconds(0.5f);
        contref.balldestroyed = false;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
           if(contref.balldestroyed == false)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            
        }
        else if(collision.gameObject.tag == "orange")
        {
            if(collision.gameObject.GetComponent<Peg>().collidedwith == false)
            scoreref.addOrangeScore();
        }
        else if (collision.gameObject.tag == "blue")
        {
            if(collision.gameObject.GetComponent<Peg>().collidedwith == false)
            scoreref.addBlueScore();
        }
    }
}
