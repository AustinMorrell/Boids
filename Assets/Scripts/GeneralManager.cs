using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralManager : MonoBehaviour {

    private float coh = 5.0f;
    private float dis = 10.0f;
    private float all = 25.0f;

        // Update is called once per frame
    void Update()
    {
        foreach (Flock a in FindObjectsOfType<Flock>())
        {
            a.cohesion = coh;
            a.dispersion = dis;
            a.alliment = all;
        }
    }

    public void setCoh(float d)
    {
        coh = d;
    }

    public void setDis(float d)
    {
        dis = d;
    }

    public void setAll(float d)
    {
        all = d;
    }
}
