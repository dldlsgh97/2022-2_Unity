using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePainter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blue;
    public Camera cam;    
    public bool active = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(2) || Input.touchCount > 0)
        {
            Instantiate(blue, this.transform.position, this.transform.rotation);
            blue.transform.LookAt(cam.transform.position);
        }
        


    }
}
