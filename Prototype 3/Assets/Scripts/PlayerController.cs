using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRb;
	public float jumpForce = 10;
	public float gravityModifier;
	public bool isOnGround = true;
	public bool gameOver = false;
	private Animator playerAnim;
	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	public AudioClip jumpSound;
	public AudioClip crashSound;
	private AudioSource playerAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
	playerAnim = GetComponent<Animator>();
	Physics.gravity *= gravityModifier;
	playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
	playerAudio.PlayOneShot(jumpSound, 1.0f);
	dirtParticle.Stop();
	playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
	isOnGround = false;
	playerAnim.SetTrigger("Jump_trig"); }
    }

	private void OnCollisionEnter(Collision collision) {
	if (collision.gameObject.CompareTag("Ground")) {
	isOnGround = true;
	dirtParticle.Play(); }
	else if (collision.gameObject.CompareTag("Obstacle")) {
	gameOver = true;
	Debug.Log("Game Over!"); 
	playerAudio.PlayOneShot(crashSound, 1.0f);
	explosionParticle.Play();
	dirtParticle.Stop();
	playerAnim.SetBool("Death_b", true); 
	playerAnim.SetInteger("DeathType_int", 1); } }
}
