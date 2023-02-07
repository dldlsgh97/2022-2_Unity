using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    public GameObject spawn_point;
    void Start()
    {
        spawn_point.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < plane.transform.position.y - 10)
        {
            transform.position = spawn_point.transform.position;
        }
    }
}
