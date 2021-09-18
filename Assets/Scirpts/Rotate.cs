using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotationSpeed_X = 0;
    public int rotationSpeed_Y = 0;
    public int rotationSpeed_Z = 0;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(this.rotationSpeed_X * Time.deltaTime, this.rotationSpeed_Y * Time.deltaTime, this.rotationSpeed_Z * Time.deltaTime);
    }
}
