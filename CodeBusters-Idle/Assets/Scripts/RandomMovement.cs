using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    public Collider2D bounds;
    private int i;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            print(".");
        }

        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int i = 0;
        if (i == 1)
        {
            directionVector = Vector3.right;
        }
        else if (i == 4)
        {
            directionVector = Vector3.left;
        }
        else if (i == 8)
        {
            directionVector = Vector3.right;
        }
        else if (i == 13)
        {
            directionVector = Vector3.left;
        }
        else if (i == 15)
        {
            directionVector = Vector3.right;
        }
    }
}



