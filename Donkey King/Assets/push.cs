using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public bool isbeingpushed;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        if (isbeingpushed == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
