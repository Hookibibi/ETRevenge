using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElliotRoaming : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            Player.transform.position, speed * Time.deltaTime);
        if (transform.position.x <= Player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (transform.position.x > Player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
