using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    ObstaclesManager om;

    private void Awake()
    {
        om = GameObject.FindObjectOfType<ObstaclesManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "pipe")
        {
            Destroy(other.transform.parent.transform.parent.gameObject);
            om.GenerateSingleObstacle();
        }
    }
}
