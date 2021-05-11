using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 10.0f;
    private float backBound = -5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        // If the position z is smaller than -5 it destroy the obstacle / als positie z kleiner is dan -5 het destroy de obstakel
        if(transform.position.z < backBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if(transform.position.z < backBound && gameObject.CompareTag("Gem"))
        {
            Destroy(gameObject);
        }
    }
}
