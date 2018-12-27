using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpace : MonoBehaviour {
    public new Vector3 ID;
    public GameObject sub;
    public bool Occupied;
    public int scale;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Occupied==false && Time.time>=0.01f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            this.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.05f);
            Occupied = true;
        }
        //if (scale > 1 && other.gameObject.tag=="Obstacle") Split();
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.01f);
        Occupied = false;
    }

    public void Split()
    {
        for (int x = 0; x <= 1; x++)
            for (int y = 0; y <= 1; y++)
                for (int z = 0; z <= 1; z++)
                {
                    GameObject temp = Instantiate(sub);
                    sub.SetActive(false);
                    sub.GetComponent<CubeSpace>().scale = 1;
                    Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
                    material.color = new Color(1, 1, 1, 0.01f);
                    temp.transform.parent = this.transform;
                    temp.transform.localPosition = new Vector3( 0.5f * x - 0.25f, 0.5f * y - 0.25f, 0.5f * z - 0.25f);
                    temp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    temp.GetComponent<Renderer>().material = material;
                    temp.GetComponent<CubeSpace>().ID = new Vector3(x, y, z);
                    print("Split");
                }
    }

}
