using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float xRange = 5.0f;
    public ParticleSystem explosionParticle;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        //Playermovement
        transform.Translate(Vector3.right * horizontalInput * Time.fixedDeltaTime * speed);

        //Keep the player on the ground so he don't fall of the map
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player input
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void OnCollisionEnter( Collision collision)
    {
        // If player collide with the obstacle the player is dead, hear crashsound and see particle 
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(crashSound, transform.position);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.GameOver();
        }
    }
}
