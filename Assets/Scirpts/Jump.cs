using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public int jumpHeight = 2;
    public int jumpSpeed_X = 0;
    public int jumpSpeed_Y = 0;
    public int jumpSpeed_Z = 0;
    public bool falldown = true;
    private bool falling = false;
    private float initialPosX;
    private float initialPosY;
    private float initialPosZ;

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosX = this.transform.position.x;
        this.initialPosY = this.transform.position.y;
        this.initialPosZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.falldown)
        {
        }
        else
        {
            if (this.transform.position.x > this.initialPosX + this.gameObject.GetComponent<Collider>().bounds.size.x * this.jumpHeight && !this.falling)
            {
                this.transform.position.Set(this.initialPosX, this.initialPosY, this.initialPosZ);
            }
            else
            {
                this.transform.position += new Vector3(this.jumpSpeed_X * Time.deltaTime, this.jumpSpeed_Y * Time.deltaTime, this.jumpSpeed_Z * Time.deltaTime);
            }
        }
    }
}
