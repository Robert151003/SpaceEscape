using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour
{
    public Transform leftPosition;
    public Transform rightPosition;
    public float speed = 5f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            MoveTowards(rightPosition);
            if (transform.position == rightPosition.position)
                movingRight = false;
        }
        else
        {
            MoveTowards(leftPosition);
            if (transform.position == leftPosition.position)
                movingRight = true;
        }
    }

    void MoveTowards(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
