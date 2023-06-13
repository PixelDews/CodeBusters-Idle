using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCircle : MonoBehaviour
{
    public Vector2 startPosition;
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody2D;
    public Collider2D bounds;
    private bool x;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
       while (x)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(-4, 4);
        switch(direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.left;
                break;
        }
    }
}
