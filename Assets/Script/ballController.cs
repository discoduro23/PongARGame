using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 0.01f;

    private Rigidbody rigidb;
    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);

        startPoint = transform.position;
        rigidb = GetComponent<Rigidbody>();

        FirstStart();
    }

    private void FixedUpdate()
    {
        if (rigidb.velocity.magnitude < 0.1f)
        {
            rigidb.velocity = new Vector3(speed * rigidb.velocity.normalized.x, 0, speed * rigidb.velocity.normalized.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalP1")
        {
            int player1Score = PlayerPrefs.GetInt("Player1Score", 0);
            PlayerPrefs.SetInt("Player1Score", player1Score + 1);
            ForceStart();
        }
        if (other.gameObject.tag == "GoalP2")
        {
            int player2Score = PlayerPrefs.GetInt("Player2Score", 0);
            PlayerPrefs.SetInt("Player2Score", player2Score + 1);
            ForceStart();
        }
    }

    private void ForceStart()
    {
        //Put on the central point
        rigidb.MovePosition(startPoint);

        //Get a random angle
        float angle = Random.Range(0, 360);
        while ((angle < 130 && angle > 230) || (angle > 50 && angle < 310))
        {
            angle = Random.Range(0, 360);
        }

        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void FirstStart()
    {
        //Put on the central point
        rigidb.MovePosition(startPoint);

        //Get a random angle
        float angle = Random.Range(130, 230);

        //Apply a force to the ball
        rigidb.AddForce(new Vector3(speed * Mathf.Cos(angle * Mathf.Deg2Rad), 0, speed * Mathf.Sin(angle * Mathf.Deg2Rad)), ForceMode.VelocityChange);
    }
}
