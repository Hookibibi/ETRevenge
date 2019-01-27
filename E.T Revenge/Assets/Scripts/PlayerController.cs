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
    private GameObject Blood;
    private Animator animator;
    public Collider2D PitSave;
    public Vector2 savePos;
    public Vector3 saveCam;
    public bool kill;
    public bool walk;
    public bool alive;
    public bool scan;


    void Awake()
    {
        Blood = GameObject.Find("Blood");
        Camera = GameObject.FindWithTag("MainCamera");
        UpTrigger = GameObject.FindWithTag("UpTrigger");
        DownTrigger = GameObject.FindWithTag("DownTrigger");
        LeftTrigger = GameObject.FindWithTag("LeftTrigger");
        RightTrigger = GameObject.FindWithTag("RightTrigger");
        animator = GetComponent<Animator>();
        alive = true;
        scan = false;
        kill = false;
        if (Camera == null)
            Debug.Log("Problem");
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "UpTrigger")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + 10, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x, UpTrigger.transform.position.y + 10, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x, DownTrigger.transform.position.y + 10, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x, LeftTrigger.transform.position.y + 10, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x, RightTrigger.transform.position.y + 10, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "DownTrigger")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 10, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x, UpTrigger.transform.position.y - 10, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x, DownTrigger.transform.position.y - 10, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x, LeftTrigger.transform.position.y - 10, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x, RightTrigger.transform.position.y - 10, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "LeftTrigger")
        {
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x - 21.143f, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x - 21.143f, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x - 21.143f, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x - 21.143f, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x - 21.143f, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "RightTrigger")
        {
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x + 21.143f, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x + 21.143f, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x + 21.143f, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x + 21.143f, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x + 21.143f, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "PitNormal" && in_pit == false)
        {
            in_pit = true;
            end_fall = false;
            savePos = transform.position;
            saveCam = Camera.transform.position;
            transform.position = new Vector2(47.63f, 13.61f);
            Camera.transform.position = new Vector3(47.69f, 10.13f, Camera.transform.position.z);
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
//            other.GetComponent<PolygonCollider2D>().enabled = false;
            PitSave = other;
        }
        else if (other.gameObject.tag == "PitUp")
        {
            PitSave.gameObject.tag = "PitCurrent";
            Camera.transform.position = saveCam;
            transform.position = savePos;
            rb2d.gravityScale = 0;
            GetComponent<Collider2D>().isTrigger = true;
        }
        else if (other.gameObject.tag == "Elliot")
        {
            Blood.transform.position = other.gameObject.transform.position;
            Destroy(other.gameObject);
            kill = true;
        }
    }

    IEnumerator CreateBlood()
    {
        Blood.SetActive(true);
        yield return new WaitForSeconds(2);
        Debug.Log("End for wait");
        Destroy(Blood);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PitCurrent")
        {
            in_pit = false;
            PitSave.gameObject.tag = "PitNormal";
 //           other.GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("Exit");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Sol")
        {
            end_fall = true;
            rb2d.gravityScale = 0;
            animator.SetTrigger("playerIdle");
        }
    }

    void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
        }
        if (kill == true)
        {
            StartCoroutine(CreateBlood());
            kill = false;
        }
        if (alive == true)
        {
            if (in_pit == false)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                if (moveHorizontal > 0)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else if (moveHorizontal < 0)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                if (!(moveHorizontal == 0f && moveVertical == 0f))
                {
                    scan = false;
                    walk = true;
                    animator.SetTrigger("playerWalk");
                }
                else if (Input.GetKeyDown("space"))
                {
                    Debug.Log("scan");
                    walk = false;
                    scan = true;
                    animator.SetTrigger("playerScan");
                }
                else if (!(Input.GetKeyDown("space")) && scan == false)
                {
                    scan = false;
                    animator.SetTrigger("playerIdle");
                }
                else
                {
                    scan = false;
                    walk = false;
                    animator.SetTrigger("playerIdle");
                }
                Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
                rb2d.MovePosition(rb2d.position + movement);
                if (transform.position.x > 70)
                    transform.position = new Vector2(40, transform.position.y);
                else if (transform.position.x < -9f)
                    transform.position = new Vector2(-9f, transform.position.y);
                if (transform.position.y < -4f)
                    transform.position = new Vector2(transform.position.x, -4);
                else if (transform.position.y > 22f)
                    transform.position = new Vector2(transform.position.x, 14f);
            }
            else if (in_pit == true && end_fall == true)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                if (moveVertical > 0.0f)
                {
                    if (scan == false)
                        animator.SetTrigger("playerScan");
                    scan = true;
                    Debug.Log("scan");
                }
                else if (moveHorizontal != 0.0f)
                {
                    scan = false;
                    animator.SetTrigger("playerWalk");
                }
                if (moveHorizontal > 0)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else if (moveHorizontal < 0)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                Vector2 movement;
                if (moveVertical == 0)
                    movement = new Vector2(moveHorizontal * speed, -1 * speed);
                else
                    movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
                rb2d.MovePosition(rb2d.position + movement);
            }
        }
    }
}
