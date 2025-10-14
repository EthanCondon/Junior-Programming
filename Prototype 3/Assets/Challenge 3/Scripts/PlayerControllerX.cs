using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 10f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // max height before you can’t float higher
    private float upperLimit = 14f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down * 9.81f * gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        // float while space is pressed AND below height limit
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < upperLimit)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Force);
        }

        // optional: if too high, gently push them down
        if (transform.position.y > upperLimit)
        {
            transform.position = new Vector3(transform.position.x, upperLimit, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}
