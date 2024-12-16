using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    Vector3 oldVel;
    Rigidbody body;
    bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        oldVel = body.velocity;
        isReady = false;
    }

    const float maxScale = 14;

    public bool IsReady()
    {
        return isReady;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 oldScale = transform.localScale;
        if (oldScale.x >= maxScale - (maxScale / 6))
        {
            isReady = true;
        }
        oldScale.x += Mathf.Abs(Mathf.Abs(body.velocity.x) - Mathf.Abs(oldVel.x)) / 8.2f;
        oldScale.x += Mathf.Abs(Mathf.Abs(body.velocity.z) - Mathf.Abs(oldVel.z)) / 8.2f;
        oldScale.y += Mathf.Abs(Mathf.Abs(body.velocity.x) - Mathf.Abs(oldVel.x)) / 8.2f;
        oldScale.y += Mathf.Abs(Mathf.Abs(body.velocity.z) - Mathf.Abs(oldVel.z)) / 8.2f;
        oldScale.z += Mathf.Abs(Mathf.Abs(body.velocity.x) - Mathf.Abs(oldVel.x)) / 8.2f;
        oldScale.z += Mathf.Abs(Mathf.Abs(body.velocity.z) - Mathf.Abs(oldVel.z)) / 8.2f;
        if (oldScale.x >= maxScale)
        {
            oldScale.x = maxScale;
            oldScale.y = maxScale;
            oldScale.z = maxScale;
        }
        transform.localScale = oldScale;
        oldVel = body.velocity;
    }
}
