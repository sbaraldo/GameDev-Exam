using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 15.0f;
    private float backBound = -5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        // If the position z is smaller than -5 it destroy the obstacle / als positie z kleiner is dan -5 het vernietigd de obstakel
        if(transform.position.z < backBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        // If the position z is smaller than -5 it destroy the gem / als positie z kleiner is dan -5 het vernietigd de gem
        if(transform.position.z < backBound && gameObject.CompareTag("Gem"))
        {
            Destroy(gameObject);
        }
    }
}
