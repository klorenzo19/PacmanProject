using System;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PacMovement : MonoBehaviour
{
    public Animator animator;
    public AudioSource movementAudio;
    public float moveSpeed = 2.0f;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private int currentDirection = 3;
    private Vector3[] path;

    void Start()
    {
        targetPosition = transform.position;

        path = new Vector3[]
        {
            new Vector3(5, 0, 0),
            new Vector3(0, (float) -3.8, 0),
            new Vector3(-5, 0, 0),
            new Vector3(0, (float) 3.8, 0)
        };

        StartMoving();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
            if (Vector3.Distance(transform.position, targetPosition) == 0)
            {
                isMoving = false;
                movementAudio.Stop();
            }
        }
        else
        {
            StartMoving();
        }

        //Debug.Log("IsWalking: " + animator.GetBool("IsWalking"));
    }

    private void StartMoving()
    {
        Debug.Log(targetPosition);
        Debug.Log(transform.position);

        if (targetPosition == transform.position)
        {
            targetPosition = GetNextPosition();
            isMoving = true;
            movementAudio.Play();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        float xDiff = targetPosition.x - transform.position.x;
        float yDiff = targetPosition.y - transform.position.y;

        //Debug.Log(xDiff);
        //Debug.Log(yDiff);

        if (xDiff > 0)
        {
            animator.Play("WalkRight");
        }
        else if (xDiff < 0)
        {
            animator.Play("WalkLeft");
        }
        else if (yDiff > 0)
        {
            animator.Play("WalkUp");
        }
        else if (yDiff < 0)
        {
            animator.Play("WalkDown");
        }
    }

    private Vector3 GetNextPosition()
    {
        currentDirection = currentDirection + 1;

        if (currentDirection > path.Length){
            currentDirection = 0;
        }

        return transform.position + path[currentDirection];
    }
}
