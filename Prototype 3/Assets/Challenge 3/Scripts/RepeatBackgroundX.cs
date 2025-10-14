using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        // Save the starting position of the background
        startPos = transform.position;

        // Get the width of the background from its collider (use X, not Y!)
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        // If background moves left beyond its width, reset to start
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}

