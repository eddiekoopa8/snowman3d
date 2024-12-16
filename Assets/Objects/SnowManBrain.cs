using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManBrain : MonoBehaviour
{
    MeshRenderer bodyMesh;
    MeshRenderer headMesh;

    bool doneBody;
    bool doneHead;
    bool doneSnowMan;
    // Start is called before the first frame update
    void Start()
    {
        bodyMesh = transform.Find("Snowbody").GetComponent<MeshRenderer>();
        headMesh = transform.Find("Snowhead").GetComponent<MeshRenderer>();

        bodyMesh.enabled = false;
        headMesh.enabled = false;

        doneBody = false;
        doneHead = false;
    }

    // Update is called once per frame
    void Update()
    {
        bodyMesh.enabled = doneBody;
        headMesh.enabled = doneHead;
        doneSnowMan = doneBody && doneHead;
    }

    void OnCollisionEnter(Collision collision)
    {
        doneSnowMan = doneBody && doneHead;
        if (collision.gameObject.GetComponent<Snowball>() != null) // Is snowball (by checking if it has snowball logic)
        {
            if (collision.gameObject.GetComponent<Snowball>().IsReady() && !doneSnowMan)
            {
                Debug.Log("SNOWBALL CONVERTED TO SNOWMAN LIMB");
                Destroy(collision.gameObject);

                if (!doneBody)
                {
                    doneBody = true;
                }
                else
                {
                    doneHead = true;
                }
            }
        }
    }
}
