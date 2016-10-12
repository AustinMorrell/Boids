using UnityEngine;
using System.Collections;

public class Multiply : MonoBehaviour {

    [SerializeField]
    private GameObject SpherePre;

    [SerializeField]
    private float numbSpheres;

    private bool rev;
    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < numbSpheres; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(SpherePre, position, spawnRotation);
        }
    }
}
