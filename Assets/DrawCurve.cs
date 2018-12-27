using UnityEngine;
using System.Collections;
//using Vectrosity;
using System.Collections.Generic;

public class DrawCurve:MonoBehaviour
{
    public Material lineMat;
    public int segment = 20;
    //VectorLine line;
    public Transform[] poss = new Transform[3];

    List<Vector3> m_points3;

    public GameObject cubePrefab;


    public LineRenderer lineRenderer;
    public Color c1 = new Color(0.8f, 0.8f, 0, 0.4f);
    public Color c2 = new Color(0.8f, 0.8f, 0, 0.4f);
    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = lineMat;
        lineRenderer.startColor = c1;
        lineRenderer.endColor = c2;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = segment;
    }

    public void makeCurve(Vector3 anchor1, Vector3 control1, Vector3 anchor2, Vector3 control2, int segments)
    {
        m_points3 = new List<Vector3>(segment);
        for (int i = 0; i < segment; i++)
        {
            Vector3 pp = GetBezierPoint3D(ref anchor1, ref control1, ref anchor2, ref control2, (float)i / segments, cubePrefab);
            m_points3.Add(pp);
        }
        int j = 0;
        while (j < m_points3.Count)
        {
            lineRenderer.SetPosition(j, m_points3[j]);
            j++;
        }
    }

    private static Vector3 GetBezierPoint3D(ref Vector3 anchor1, ref Vector3 control1, ref Vector3 anchor2, ref Vector3 control2, float t, GameObject go)
    {
        float cx = 3 * (control1.x - anchor1.x);
        float bx = 3 * (control2.x - control1.x) - cx;
        float ax = anchor2.x - anchor1.x - cx - bx;
        float cy = 3 * (control1.y - anchor1.y);
        float by = 3 * (control2.y - control1.y) - cy;
        float ay = anchor2.y - anchor1.y - cy - by;
        float cz = 3 * (control1.z - anchor1.z);
        float bz = 3 * (control2.z - control1.z) - cz;
        float az = anchor2.z - anchor1.z - cz - bz;

        return new Vector3((ax * (t * t * t)) + (bx * (t * t)) + (cx * t) + anchor1.x,
                            (ay * (t * t * t)) + (by * (t * t)) + (cy * t) + anchor1.y,
                            (az * (t * t * t)) + (bz * (t * t)) + (cz * t) + anchor1.z);
    }

    // Update is called once per frame
    void Update()
    {
        //makeCurve(poss[0].position, poss[1].position, poss[2].position, poss[2].position, segment);
    }
}
