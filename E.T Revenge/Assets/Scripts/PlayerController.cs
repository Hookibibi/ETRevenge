using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool in_pit;
    public bool end_fall;

    private Rigidbody2D rb2d;

    void Start()
    {
        in_pit = false;
        rb2d = GetComponent<Rigidbody2D>();
     //   rb2d.gravityScale = 10;
    }

    public GameObject Camera;
    public GameObject UpTrigger;
    public GameObject DownTrigger;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;
    public Vector2 savePos;
    public Vector3 saveCam;

    void Awake()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        UpTrigger = GameObject.FindWithTag("UpTrigger");
        DownTrigger = GameObject.FindWithTag("DownTrigger");
        LeftTrigger = GameObject.FindWithTag("LeftTrigger");
        RightTrigger = GameObject.FindWithTag("RightTrigger");
        if (Camera == null)
            Debug.Log("Problem");
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "UpTrigger")
        {
            Debug.Log("Up");
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + 10, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x, UpTrigger.transform.position.y + 10, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x, DownTrigger.transform.position.y + 10, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x, LeftTrigger.transform.position.y + 10, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x, RightTrigger.transform.position.y + 10, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "DownTrigger")
        {
            Debug.Log("Down");
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 10, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x, UpTrigger.transform.position.y - 10, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x, DownTrigger.transform.position.y - 10, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x, LeftTrigger.transform.position.y - 10, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x, RightTrigger.transform.position.y - 10, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "LeftTrigger")
        {
            Debug.Log("Down");
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x - 21.143f, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x - 21.143f, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x - 21.143f, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x - 21.143f, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x - 21.143f, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "RightTrigger")
        {
            Debug.Log("Down");
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x + 21.143f, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x + 21.143f, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x + 21.143f, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x + 21.143f, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x + 21.143f, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "PitNormal")
        {
            in_pit = true;
            end_fall = false;
            savePos = transform.position;
            saveCam = Camera.transform.position;
            transform.position = new Vector2(47.63f, 13.61f);
            Camera.transform.position = new Vector3(47.69f, 10.13f, Camera.transform.position.z);
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Sol")
        {
            end_fall = true;
        }
    }

    void FixedUpdate()
    {
        if (in_pit == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (moveHorizontal < 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
            rb2d.MovePosition(rb2d.position + movement);
            if (transform.position.x > 40)
                transform.position = new Vector2(40, transform.position.y);
            else if (transform.position.x < -9f)
                transform.position = new Vector2(-9f, transform.position.y);
            if (transform.position.y < -4f)
                transform.position = new Vector2(transform.position.x, -4);
            else if (transform.position.y > 14f)
                transform.position = new Vector2(transform.position.x, 14f);
        }
        else if (in_pit == true && end_fall == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            if (moveHorizontal > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (moveHorizontal < 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector2 movement = new Vector2(moveHorizontal * speed, 0f);
            rb2d.MovePosition(rb2d.position + movement);
        }
    }
}
