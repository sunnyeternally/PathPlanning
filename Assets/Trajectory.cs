using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {
    public float kF1, kF;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        CubeSpace temp;
        if ((temp = other.GetComponent<CubeSpace>()) != null)
        {
            if (temp.Occupied)
            {
                Vector3 Distance = this.transform.position - other.transform.position;
                float x = Distance.x;
                float y = Distance.y;
                float z = Distance.z;
                if (Mathf.Abs(x) > 2) x = 0;
                else if (Mathf.Abs(x) > 1) x = kF1 * (Distance.x - 1);
                else if (Mathf.Abs(x) < 1) x = kF * 1.0f / Distance.x;


                if (Mathf.Abs(y) > 2) y = 0;
                else if (Mathf.Abs(y) > 1) y = kF1 * (Distance.y - 1);
                else if (Mathf.Abs(y) < 1) y = kF * 1.0f / Distance.y;

                if (Mathf.Abs(z) > 2) z = 0;
                else if (Mathf.Abs(z) > 1) z = kF1 * (Distance.z - 1);
                else if (Mathf.Abs(z) < 1) z = kF * 1.0f / Distance.z;

                transform.position += new Vector3(x, y, z);
            }
        }

    }
}
