using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float sensitivityMouseRot;
    public float sensitivityMouseTrans;
    public float yaw,pitch;
    // Use this for initialization
    void Start () {
        yaw = this.transform.rotation.eulerAngles.y;
	}


    void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newpos = transform.position + transform.rotation * (new Vector3(0, 0, Input.mouseScrollDelta.y* sensitivityMouseTrans));
            if ((newpos-new Vector3(10,0,10)).magnitude < 40)
                this.transform.position = newpos;
        }

        if (Input.GetMouseButton(1))
        {
            pitch += -Input.GetAxis("Mouse Y") * sensitivityMouseRot;
            yaw += Input.GetAxis("Mouse X") * sensitivityMouseRot;
            transform.rotation = Quaternion.Euler(new Vector3(pitch, yaw, 0));
        }
        else if(Input.GetMouseButton(2))
        {
            Vector3 newpos = transform.position + transform.rotation * (new Vector3(-Input.GetAxis("Mouse X") * sensitivityMouseTrans, 0, 0));
            if ((newpos - new Vector3(10, 0, 10)).magnitude < 40)
                this.transform.position = newpos;
            
            newpos = transform.position + transform.rotation * (new Vector3(0, -Input.GetAxis("Mouse Y") * sensitivityMouseTrans, 0));
            if ((newpos - new Vector3(10, 0, 10)).magnitude < 40)
                this.transform.position = newpos;
        }
    
	}

    public float AngleLimit(float angle)
    {
        if (angle > 180) angle -= 360;
        else if (angle < -180) angle += 360;

        return angle;
    }
}
