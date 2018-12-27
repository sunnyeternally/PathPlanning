using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRTNode : MonoBehaviour {
    public GameObject parent;
    public Vector3 Target;
    public List<GameObject> childs;
    public GameObject ToTargetProbe;
    public GameObject ToParentProbe;
    public GameObject ToParent;
    public ColideProbe totarget, toparent;
    GameObject Node;

    public void Initialize(GameObject creator, Vector3 Position, Vector3 target)
    {
        parent = creator;
        this.gameObject.transform.parent = parent.transform;
        transform.position = Position;

        Target = target;

        ToTargetProbe.transform.localScale = new Vector3(2.5f, 2.5f, (target - transform.position).magnitude / 0.4f);
        if ((target - transform.position).magnitude != 0)
        {
            ToTargetProbe.transform.localRotation = Quaternion.LookRotation(target - transform.position);
        }

        if ((parent.transform.position - transform.position).magnitude != 0)
        {
            ToParentProbe.transform.localRotation = Quaternion.LookRotation(parent.transform.position - transform.position);
        }
        ToParentProbe.transform.localScale = new Vector3(2.5f, 2.5f, (parent.transform.position - transform.position).magnitude / 0.4f);
        ToParent.transform.localPosition = new Vector3(0, 0.5f, 0);

        totarget.birth = Time.time;
        totarget.wait = true;
        toparent.birth = Time.time;
        toparent.wait = true;
    }

    public void Grow()
    {
        GameObject Child = Instantiate(Node);
        Child.GetComponent<RRTNode>().Initialize(this.gameObject, this.transform.position + new Vector3(Random.Range(-4,4), Random.Range(-4, 4), Random.Range(-4, 4)),Target);
        childs.Add(Child);
    }

    // Use this for initialization
    void Start () {
        Node = (GameObject)Resources.Load("Prefabs/Node", typeof(GameObject));
    }

    // Update is called once per frame
    void Update () {
		if(!toparent.wait)
        {
            if(!toparent.Clear())
            {
                this.parent.GetComponent<RRTNode>().childs.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
               
            }
        }
	}
}
