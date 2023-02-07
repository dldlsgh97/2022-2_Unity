using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marker : MonoBehaviour
{
    // Start is called before the first frame update
    public bool marker1;
    public bool marker2;
    public bool marker3;

    public int num_of_marker = 3;
    public Text text_num;

    public void Onmarker1()
    {
        marker1 = true;
        num_of_marker = num_of_marker + 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    public void Offmarker1()
    {
        marker1 = false;
        num_of_marker = num_of_marker - 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    public void Onmarker2()
    {
        marker2 = true;
        num_of_marker = num_of_marker + 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    public void Offmarker2()
    {
        marker2 = false;
        num_of_marker = num_of_marker - 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    public void Onmarker3()
    {
        marker3 = true;
        num_of_marker = num_of_marker + 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    public void Offmarker3()
    {
        marker3 = false;
        num_of_marker = num_of_marker - 1;
        text_num.text = "num_of_marker: " + num_of_marker;
        Debug.Log(num_of_marker);
    }

    void Start()
    {
        text_num.text = "num_of_marker: " + 0;
        Debug.Log(num_of_marker);
    }

    /*
    private void Update()
    {
        if(num_of_marker <= 0)
        {
            text_num.text = "num_of_marker: " + 0;
        }
    }
    */
    
}
