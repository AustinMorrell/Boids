using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GeneralManager : MonoBehaviour {

    [SerializeField]
    private Slider c;
    [SerializeField]
    private Slider d;
    [SerializeField]
    private Slider z;

    // Update is called once per frame
    void Update()
    {
        foreach (Flock a in FindObjectsOfType<Flock>())
        {
            a.cohesion = c.value;
            a.dispersion = d.value;
            a.alliment = z.value;
        }
    }
}
