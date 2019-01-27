using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        StartCoroutine(UpdateHealth());
     //   rb2d.gravityScale = 10;
    }

    public GameObject Camera;
    public GameObject UpTrigger;
    public GameObject DownTrigger;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;
    public GameObject Corpse;
    public GameObject Rocket;
    public AudioClip eatSound;
    public AudioClip fallSound;
    public AudioClip deathSound;
    public AudioClip build1Sound;
    public AudioClip build2Sound;
    public AudioClip build3Sound;
    public AudioClip gameoverSound;
    public AudioClip captureSound;
    public AudioClip footstepSound;
    public AudioClip footstep2Sound;
    public AudioClip winSound;
    public AudioClip rocketSound;
    private AudioSource source;
    private GameObject Blood;
    private Animator animator;
    public Collider2D PitSave;
    public Vector2 savePos;
    public Vector3 saveCam;
    private AudioSource Music;
    public Text healthText;
    public bool kill;
    public bool walk;
    public bool alive;
    public bool scan;
    public int health;
    public int step;
    public bool elioth_alive;
    public string tag_save;
    public int parts;
    public float vol = 0.8f;

    void Awake()
    {
        Music = GameObject.Find("Music").GetComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        Blood = GameObject.Find("Blood");
        Camera = GameObject.FindWithTag("MainCamera");
        UpTrigger = GameObject.FindWithTag("UpTrigger");
        DownTrigger = GameObject.FindWithTag("DownTrigger");
        LeftTrigger = GameObject.FindWithTag("LeftTrigger");
        RightTrigger = GameObject.FindWithTag("RightTrigger");
        Corpse = GameObject.Find("Corpse");
        Rocket = GameObject.Find("Rocket");
        Rocket.GetComponent<SpriteRenderer>().enabled = false;
        animator = GetComponent<Animator>();
        alive = true;
        scan = false;
        kill = false;
        parts = 0;
        health = 60;
        healthText.text = "Health : " + health.ToString();
        step = 0;
        elioth_alive = true;
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
        else if (other.gameObject.tag == "PitNormal"
            && in_pit == false)
        {
            in_pit = true;
            end_fall = false;
            source.PlayOneShot(fallSound, vol);
            savePos = transform.position;
            saveCam = Camera.transform.position;
            if (other.gameObject.tag == "PitNormal")
            {
                transform.position = new Vector2(81f, 5.76f);
                Camera.transform.position = new Vector3(80f, 3.70f, Camera.transform.position.z);
            }
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
            PitSave = other;
        }
        else if (other.gameObject.tag == "PitPickup1")
        {
            in_pit = true;
            end_fall = false;
            source.PlayOneShot(fallSound, vol);
            savePos = transform.position;
            saveCam = Camera.transform.position;
            transform.position = new Vector2(81f, -13.0f);
            Camera.transform.position = new Vector3(80f, -14.8f, Camera.transform.position.z);
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
            PitSave = other;
        }
        else if (other.gameObject.tag == "PitPickup2")
        {
            in_pit = true;
            end_fall = false;
            source.PlayOneShot(fallSound, vol);
            savePos = transform.position;
            saveCam = Camera.transform.position;
            transform.position = new Vector2(81f, -33.0f);
            Camera.transform.position = new Vector3(80f, -34.8f, Camera.transform.position.z);
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
            PitSave = other;
        }
        else if (other.gameObject.tag == "PitPickup3")
        {
            in_pit = true;
            end_fall = false;
            savePos = transform.position;
            source.PlayOneShot(fallSound, vol);
            saveCam = Camera.transform.position;
            transform.position = new Vector2(81f, -53.0f);
            Camera.transform.position = new Vector3(80f, -54.8f, Camera.transform.position.z);
            rb2d.gravityScale = 2;
            GetComponent<Collider2D>().isTrigger = false;
            PitSave = other;
        }
        else if (other.gameObject.tag == "PitUp")
        {
            tag_save = PitSave.gameObject.tag;
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
            source.PlayOneShot(eatSound, vol);
            kill = true;
            health += 50;
            if (alive == false)
            {
                Music.UnPause();
                Corpse.transform.position = new Vector2(-100, -100);
                GetComponent<SpriteRenderer>().enabled = true;
                alive = true;
            }
            elioth_alive = false;
        }
        else if (other.gameObject.tag == "Pickup")
        {
            parts++;
            Debug.Log(parts.ToString());
            if (parts == 1)
                source.PlayOneShot(build1Sound, vol);
            else if (parts == 2)
                source.PlayOneShot(build2Sound, vol);
            else if (parts == 3)
                source.PlayOneShot(build3Sound, vol);
            if (parts == 3)
            {
                Rocket.GetComponent<SpriteRenderer>().enabled = true;
                alive = false;
                transform.position = new Vector2(100, 100);
                Camera.transform.position = new Vector3(0f, 10f, Camera.transform.position.z);
                StartCoroutine(RocketGo());
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Cop")
        {
            health = 1;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Doctor")
        {
            transform.position = new Vector3(20, 0, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 10, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x, UpTrigger.transform.position.y - 10, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x, DownTrigger.transform.position.y - 10, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x, LeftTrigger.transform.position.y - 10, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x, RightTrigger.transform.position.y - 10, RightTrigger.transform.position.z);
            alive = false;
            source.PlayOneShot(captureSound, vol);
            StartCoroutine(InJail());
        }
        else if (other.gameObject.tag == "Water")
        {
            health = 1;
        }
    }

    IEnumerator InJail()
    {
        yield return new WaitForSeconds(3);
        alive = true;
    }

    IEnumerator RocketGo()
    {
        Music.Stop();
        source.PlayOneShot(rocketSound, vol);
        while (Rocket.transform.position.y < 20)
        {
            Rocket.transform.position = new Vector2(Rocket.transform.position.x, Rocket.transform.position.y + 0.02f);
            yield return new WaitForSeconds(0.0002f);
        }
        source.PlayOneShot(winSound, vol);
        yield return new WaitForSeconds(3);
        Application.Quit();
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
            PitSave.gameObject.tag = tag_save;
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
        if (other.gameObject.tag == "PickUp")
        {
            parts++;
            Destroy(other.gameObject);
        }
    }

    IEnumerator UpdateHealth()
    {
        while (true)
        {
            if (alive == true)
                health--;
            healthText.text = "Health : " + health.ToString();
            if (health <= 0 && alive == true)
            {
                Music.Pause();
                if (elioth_alive == true)
                    source.PlayOneShot(deathSound, vol);
                else
                {
                    alive = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Corpse.transform.position = transform.position;
                    source.PlayOneShot(gameoverSound, vol);
                    yield return new WaitForSeconds(3);
                    Application.Quit();
                }
                alive = false;
                GetComponent<SpriteRenderer>().enabled = false;
                Corpse.transform.position = transform.position;
                //                animator.SetTrigger("playerDeath");
            }
            yield return new WaitForSeconds(1);
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
                    if (source.isPlaying == false)
                    {
                        if (step == 0)
                        {
                            source.PlayOneShot(footstepSound, vol);
                            step = 1;
                        }
                        else
                        {
                            source.PlayOneShot(footstep2Sound, vol);
                            step = 0;
                        }
                    }
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
                if (transform.position.x > 50)
                    transform.position = new Vector2(50, transform.position.y);
                else if (transform.position.x < -9f)
                    transform.position = new Vector2(-9f, transform.position.y);
                if (transform.position.y < -4f)
                    transform.position = new Vector2(transform.position.x, -4);
                else if (transform.position.y > 23f)
                    transform.position = new Vector2(transform.position.x, 23f);
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
