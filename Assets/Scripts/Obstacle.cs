using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed;

    Vector3 movement;
    Rigidbody rb;
    ObstaclesManager om;

    private void Awake()
    {
        om = GameObject.FindObjectOfType<ObstaclesManager>();
        rb = transform.GetComponent<Rigidbody>();
        speed = om.speed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = om.speed;
    }

    void FixedUpdate()
    {
        if (!om.gameOver)
        {
            movement.Set(-1f, 0f, 0f);
            movement = movement.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
    }
}
