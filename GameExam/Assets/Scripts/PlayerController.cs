using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Playermovement
        transform.Translate(Vector3.right * horizontalInput * Time.fixedDeltaTime * speed);
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //Player input
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
