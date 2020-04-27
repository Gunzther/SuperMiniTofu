using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tofu : MonoBehaviour
{
    public float smoothing;
    public float offset;

    Camera cam;
    Vector3 mousePos;
    ObstaclesManager om;
    Rigidbody rb;

    private void Awake()
    {
        cam = Camera.main;
        om = GameObject.FindObjectOfType<ObstaclesManager>();
        rb = transform.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!om.gameOver)
        {
            Vector3 inputMousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(new Vector3(inputMousePos.x, inputMousePos.y, cam.nearClipPlane));
            Vector3 targetPos = new Vector3(transform.position.x, mousePos.y - offset, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        om.GameOver();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "wall")
        {
            om.GameOver();
            rb.isKinematic = true;
        }
    }
}
