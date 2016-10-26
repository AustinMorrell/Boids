using UnityEngine;
using System.Collections.Generic;

public class Flock : MonoBehaviour {

    [Range(100, 1)]
    public float cohesion = 5.0f;
    [Range(1, 100)]
    public float dispersion = 10.0f;
    [Range(100, 1)]
    public float alliment = 25.0f;
    [Range(1, 5000)]
    public float vlim = 1000;
    public Vector3 place = new Vector3(0, 0, 0);
    public Vector3 wind = new Vector3(5, 5, 5);
    [Range(1, 100)]
    public int Xmin = 25, Xmax = 25, Ymin = 25, Ymax = 25, Zmin = 25, Zmax = 25;
    public float groundLevel = 0;
    public bool perching;

    // ----------------------------------------------------------------------

    [SerializeField]
    private GameObject SpherePre;

    private static int numbSpheres = 25;

    private Seak[] DemBoids = new Seak[numbSpheres];
    void Start()
    {
        for (int i = 0; i < numbSpheres; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
            Vector3 Velo = new Vector3(Random.Range(1.0f, 6.0f), Random.Range(1.0f, 6.0f), Random.Range(1.0f, 6.0f));
            Quaternion spawnRotation = Quaternion.identity;
            GameObject a = (GameObject)Instantiate(SpherePre, position, spawnRotation);
            a.GetComponent<Seak>().m_Velocity = Velo;
            DemBoids[i] = a.GetComponent<Seak>();
        }
        perching = false;
    }

    // --------------------------------------------
    void Update()
    {
        Vector3 v1, v2, v3, v4, v5, v6, v7;
        foreach (Seak b in DemBoids)
        {
            if (!perching)
            {
                v1 = Rule1(b);
                v2 = Rule2(b);
                v3 = Rule3(b);
                v4 = Rule4(b);
                v5 = Rule5(b);
                v6 = Rule6(b);
                Rule7(b);
                b.m_Velocity = b.m_Velocity + v1 + v2 + v3 + v4 + v5 + v6;

                b.transform.position = b.transform.position + b.m_Velocity.normalized;
            }
            else
            {
                b.m_Velocity = new Vector3(b.m_Velocity.x, groundLevel, b.m_Velocity.z);
                b.transform.position = b.transform.position + b.m_Velocity.normalized;
            }
        }
    }

    private Vector3 Rule1(Seak b)
    {
        Vector3 pc = new Vector3(0, 0, 0);

        for (int i = 0; i < numbSpheres; i++)
        {
            if (DemBoids[i] != b)
            {
                pc += DemBoids[i].transform.position;
            }
        }

        pc /= (numbSpheres - 1);

        return (pc - b.transform.position) / cohesion;
    }

    private Vector3 Rule2(Seak b)
    {
        Vector3 c = new Vector3(0,0,0);
        for (int i = 0; i < numbSpheres; i++)
        {
            if (DemBoids[i] != b)
            {
                float Mag = Vector3.Distance(DemBoids[i].transform.position, b.transform.position);
                if (Mathf.Abs(Mag) < dispersion)
                {
                    c = c - (DemBoids[i].transform.position - b.transform.position);
                }
            }
        }
        return c;
    }

    private Vector3 Rule3(Seak b)
    {
        Vector3 pv = new Vector3(0, 0, 0);

        for (int i = 0; i < numbSpheres; i++)
        {
            if (DemBoids[i] != b)
            {
                pv += DemBoids[i].m_Velocity;
            }
        }
        pv /= (numbSpheres - 1);

        return (pv - b.m_Velocity) / alliment;
    }

    private Vector3 Rule4(Seak b)
    {
        return (place - b.transform.position) / 5;
    }

    private Vector3 Rule5(Seak b)
    {
        return wind;
    }

    private Vector3 Rule6(Seak b)
    {
        Vector3 v = new Vector3(0, 0, 0);

        // X
        if (b.transform.position.x < Xmin)
        {
            v = new Vector3(10, Random.Range(-10, 10), Random.Range(-10, 10));
        }
        else if (b.transform.position.x > Xmax)
        {
            v = new Vector3(-10, Random.Range(-10, 10), Random.Range(-10, 10));
        }

        // Y
        if (b.transform.position.y < Ymin)
        {
            v = new Vector3(Random.Range(-10, 10), 10, Random.Range(-10, 10));
        }
        else if (b.transform.position.y > Ymax)
        {
            v = new Vector3(Random.Range(-10, 10), -10, Random.Range(-10, 10));
        }

        // Z
        if (b.transform.position.z < Zmin)
        {
            v = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 10);
        }
        else if (b.transform.position.z > Zmax)
        {
            v = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), -10);
        }

        // ------------------------------------------------------------------------

        // X
        if (b.transform.position.x < Xmin)
        {
            v.x = 10;
        }
        else if (b.transform.position.x > Xmax)
        {
            v.x = -10;
        }

        // Y
        if (b.transform.position.y < Ymin)
        {
            v.y = 10;
        }
        else if (b.transform.position.y > Ymax)
        {
            v.y = -10;
        }

        // Z
        if (b.transform.position.z < Zmin)
        {
            v.z = 10;
        }
        else if (b.transform.position.z > Zmax)
        {
            v.z = -10;
        }

        return v;
    }

    private void Rule7(Seak b)
    {
        if (Mathf.Abs(b.m_Velocity.x) > vlim || 
            Mathf.Abs(b.m_Velocity.y) > vlim || 
            Mathf.Abs(b.m_Velocity.z) > vlim)
        {
            b.m_Velocity = Vector3.ClampMagnitude(b.m_Velocity, vlim);
        }
    }
}
