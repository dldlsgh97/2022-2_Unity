using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    SpriteRenderer ren;
    SpriteRenderer ren2;

    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
        else if (Input.GetMouseButton(0))
        {
            if (ren.enabled == true)
            {
                ren.enabled = false;
            }
            else if(ren.enabled == false)
            {
                ren.enabled = true;
            }
        }

    }
}
