using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject Camera;
    public GameObject UpTrigger;
    public GameObject DownTrigger;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;

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
            Camera.transform.position = new Vector3(Camera.transform.position.x - 21, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x - 21, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x - 21, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x - 21, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x - 21, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
        else if (other.gameObject.tag == "RightTrigger")
        {
            Debug.Log("Down");
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            Camera.transform.position = new Vector3(Camera.transform.position.x + 21, Camera.transform.position.y, Camera.transform.position.z);
            UpTrigger.transform.position = new Vector3(UpTrigger.transform.position.x + 21, UpTrigger.transform.position.y, UpTrigger.transform.position.z);
            DownTrigger.transform.position = new Vector3(DownTrigger.transform.position.x + 21, DownTrigger.transform.position.y, DownTrigger.transform.position.z);
            LeftTrigger.transform.position = new Vector3(LeftTrigger.transform.position.x + 21, LeftTrigger.transform.position.y, LeftTrigger.transform.position.z);
            RightTrigger.transform.position = new Vector3(RightTrigger.transform.position.x + 21, RightTrigger.transform.position.y, RightTrigger.transform.position.z);
        }
    }
}
