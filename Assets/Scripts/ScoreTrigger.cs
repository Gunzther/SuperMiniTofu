using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    ObstaclesManager om;
    // Start is called before the first frame update
    void Start()
    {
        om = GameObject.FindObjectOfType<ObstaclesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player") om.ScoreUp();
    }
}
