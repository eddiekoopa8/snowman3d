using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 prevPos;
    public Transform cameraPos;
    Rigidbody body;
    void Start()
    {
        prevPos = transform.position;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool moving = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.TransformDirection(new Vector3(0, 0, 0.3f)));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(transform.TransformDirection(new Vector3(0, 0, -0.3f)));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.TransformDirection(new Vector3(-0.3f, 0, 0)));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.TransformDirection(new Vector3(0.3f, 0, 0)));
        }

        // Fix player moving by themself.
        /*if (moving && body.velocity.x >= 0)
        {
            Vector3 newv = body.velocity;
            newv.x = 0;
            body.velocity = newv;
        }
        if (moving && body.velocity.y >= 0)
        {
            Vector3 newv = body.velocity;
            newv.y = 0;
            body.velocity = newv;
        }*/

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }*/

        cameraPos.position += transform.position - prevPos;
        //cameraPos.position = transform.position;
        //cameraPos.rotation = new Quaternion(transform.rotation.x * 2, transform.rotation.y * 2, transform.rotation.z * 2, transform.rotation.w * 2);
        prevPos = transform.position;
    }
}
