using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 5f;
    private PlayerControllerX playerControllerScript;
    private float leftBound = -10f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            // move in world space, not local (fixes spinning)
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (gameObject.CompareTag("Background") && transform.position.x < -15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }

        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
