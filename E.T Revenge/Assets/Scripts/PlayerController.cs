using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 10;
    }
    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (moveHorizontal < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        rb2d.MovePosition(rb2d.position + movement);
    }
}
