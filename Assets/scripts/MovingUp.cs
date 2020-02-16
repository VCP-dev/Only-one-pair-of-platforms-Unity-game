using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed=3;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        speed=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)/* Input.GetMouseButtonDown(0) */)
        {
            speed=5;
        }
        rb.velocity = new Vector2(rb.velocity.x,speed);
    }
}
