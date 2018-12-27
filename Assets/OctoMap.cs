using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoMap : MonoBehaviour {
    public GameObject CubeSpace;
    public int x_size, y_size, z_size;
	// Use this for initialization
	void Start () {
		for(int x=0;x<=x_size;x++)
            for (int y = 0; y <= y_size; y++)
                for (int z = 0; z <= z_size; z++)
                {
                    GameObject temp = Instantiate(CubeSpace);
                    Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
                    material.color = new Color(1, 1, 1, 0.01f);
                    temp.transform.parent = this.transform;
                    temp.transform.localPosition = new Vector3(1.0f*x, 1.0f * y, 1.0f * z);
                    temp.GetComponent<Renderer>().material = material;
                    if (x == x_size || y == y_size || z == z_size || x == 0 || y == 0 || z == 0) temp.GetComponent<CubeSpace>().Occupied = true;
                    temp.GetComponent<CubeSpace>().ID = new Vector3(x, y, z);
                }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
