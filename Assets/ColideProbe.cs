using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColideProbe : MonoBehaviour {
    public List<GameObject> Obstacles;
    public bool clear;
    public bool wait;
    public float birth;
	// Use this for initialization
	void Start () {
        birth = Time.time; 
        wait = true;
        Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
        material.color = new Color(0, 1, 0, 0.25f);
        this.GetComponent<Renderer>().material = material;
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Time.time - birth>0) wait = false;
        if (Obstacles.Count > 0)
        {
            clear = false;
            Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
            material.color = new Color(1, 1, 0, 0.25f);
            this.GetComponent<Renderer>().material = material;
        }
        else
        {
            clear = true;
            Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
            material.color = new Color(0, 1, 0, 0.25f);
            this.GetComponent<Renderer>().material = material;
        }
        Obstacles.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CubeSpace>()!=null)
        {
            if(other.GetComponent<CubeSpace>().Occupied)
            {
                Obstacles.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CubeSpace>() != null)
        {
            if (other.GetComponent<CubeSpace>().Occupied)
            {
                Obstacles.Add(other.gameObject);
            }
        }
    }

    public bool Clear()
    {
        return clear;
    }
}
