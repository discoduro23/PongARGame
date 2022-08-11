using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject ball = null;
    public float AIvelocity = 1f;

    private Vector3 startPos;
    private float idealReceptionPos = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        idealReceptionPos = ball.transform.position.z;

        //Move to idealReceptionPos with fixed velocity

        float diff = idealReceptionPos - transform.position.z;

        if (idealReceptionPos > transform.position.z)
        {
            transform.position += new Vector3(0, 0, AIvelocity);
        }
        else if (idealReceptionPos < transform.position.z)
        {
            transform.position += new Vector3(0, 0, -AIvelocity);
        }
        else
        {
            transform.position += new Vector3(0, 0, 0);
        }

    }
}
