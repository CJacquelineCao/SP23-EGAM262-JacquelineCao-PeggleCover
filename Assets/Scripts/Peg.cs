using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public bool collidedwith;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            collidedwith = true;
          
        }
    
    }
    public void DestroyafterCollision()
    {
        if (collidedwith == true)
        {
            Destroy(gameObject);
        }
        
    }
}
