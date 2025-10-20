using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup;
    public float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        // safety check — make sure indicator starts hidden
        if (powerupIndicator != null)
            powerupIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        if (focalPoint != null)
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (powerupIndicator != null)
	powerupIndicator.transform.position = transform.position + new Vector3(0, 0.2f, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());

            if (powerupIndicator != null)
                powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        if (powerupIndicator != null)
            powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
                Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
                enemyRigidbody.AddForce(awayFromPlayer.normalized * powerupStrength, ForceMode.Impulse);
            }
        }
    }
}
