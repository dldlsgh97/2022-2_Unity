using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    private Transform tr;
    public Transform target_tr;
    public float rot_speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.RotateAround(target_tr.position, Vector3.up, Time.deltaTime * rot_speed);
        
    }
}
