using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {
    public List<GameObject> PoCA; 
    public int targetindex;
	public Vector3 P,D;
    public float kP, kD, kF1, kF;
    public Vector3 last_post;
    public GameObject Dot;
    public Vector3 force;
    public List<GameObject> obstacles;
    // Use this for initialization
	void Start () {
        last_post = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Go();
    }

    public void Go()
    {
        P = PoCA[targetindex].transform.position - transform.position;
        D = transform.position - last_post;
        last_post = transform.position;

        transform.position += kP * P - kD * D;
        GameObject temp = Instantiate(Dot);
        temp.transform.position = transform.position;

        if(P.sqrMagnitude<0.1 && targetindex < PoCA.Count-1)
        {
            targetindex++;
        }
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
                if (Mathf.Abs(x) > 3) x = 0;
                else if (Mathf.Abs(x) > 1) x = kF1 * (Distance.x* Distance.x* Distance.x);
                else if (Mathf.Abs(x) < 1) x = 0 * kF * 1.0f / Distance.x;


                if (Mathf.Abs(y) > 3) y = 0;
                else if (Mathf.Abs(y) > 1) y = kF1 * (Distance.y* Distance.y* Distance.y);
                else if (Mathf.Abs(y) < 1) y = 0 * kF * 1.0f / Distance.y;

                if (Mathf.Abs(z) > 3) z = 0;
                else if (Mathf.Abs(z) > 1) z = kF1 * (Distance.z* Distance.z* Distance.z);
                else if (Mathf.Abs(z) < 1) z = 0 * kF * 1.0f / Distance.z;

                transform.position += new Vector3(x, y, z);
            }
        }
    }

    
    private void OnGUI()
    {
    }
}
