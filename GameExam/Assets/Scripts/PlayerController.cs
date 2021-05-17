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
    public MoveBack obstacleSpeed;
    public MoveBack gemSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        obstacleSpeed = GameObject.Find("Obstacle").GetComponent<MoveBack>();
        gemSpeed = GameObject.Find("Gem").GetComponent<MoveBack>();
    }

    void FixedUpdate()
    {
        //Playermovement / Speler beweging
        transform.Translate(Vector3.right * horizontalInput * Time.fixedDeltaTime * speed);

        //Keep the player on the ground so he don't fall of the map / speler kan niet van de map af vallen
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
        //Player input / speler invoer
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void OnCollisionEnter( Collision collision)
    {
        // If player collide with the obstacle the player is dead, hear crashsound and see particle
        // als speler tegen object botst de speler is dood, je hoort crashsound en ziet een particle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(crashSound, transform.position);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player collide with the gem the score will add and obstacle speed increase
        // als speler tegen gem botst de score word toegevoegd en obstakel snelheid verhoogd
        if(other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            gameManager.score += 1;
            gameManager.UpdateScore(gameManager.score);
            obstacleSpeed.speed += 1f;
            gemSpeed.speed += 1f;
        }
    }
}
