﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElliotRoaming : MonoBehaviour
{
    private GameObject Player;
    private GameObject Music;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Music = GameObject.Find("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerController>().alive == true &&
            Player.GetComponent<PlayerController>().in_pit == false)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                Player.transform.position, speed * Time.deltaTime);
            if (transform.position.x <= Player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (transform.position.x > Player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Player.GetComponent<PlayerController>().alive == false &&
            Player.GetComponent<PlayerController>().in_pit == false &&
            name == "Elliot")
        {
            transform.position = Vector2.MoveTowards(transform.position,
                Player.transform.position, 3 * Time.deltaTime);
            if (transform.position.x <= Player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (transform.position.x > Player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
