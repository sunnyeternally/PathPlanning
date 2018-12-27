using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRTSolver : MonoBehaviour {
    public Vector3 StartPoint, EndPoint;
    public bool solving;
    public GameObject Root;
    GameObject Node;
    // Use this for initialization
    void Start () {
		Node =  (GameObject)Resources.Load("Prefabs/Node", typeof(GameObject));
    }
	
	// Update is called once per frame
	void Update () {
        if (solving)
        {  
            if(Root.GetComponent<RRTNode>().childs.Count<5)
            Root.GetComponent<RRTNode>().Grow();
        }
    }

    public void Solve(Vector3 Start, Vector3 End)
    {
        solving = true;
        this.transform.position = Start;
        Root = Instantiate(Node);
        Root.GetComponent<RRTNode>().Initialize(this.gameObject,Start, End);
        

        
    }
}
