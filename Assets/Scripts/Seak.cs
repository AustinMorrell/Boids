using UnityEngine;
using System.Collections;

public class Seak : MonoBehaviour {

    [SerializeField]
    GameObject Box;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        Lerp(Box.transform.position.x * Time.deltaTime,
            Box.transform.position.y * Time.deltaTime,
            Box.transform.position.z * Time.deltaTime);
	}

    void Lerp(float a, float b, float c)
    {
        gameObject.transform.position = new Vector3(
            transform.position.x + a, 
            transform.position.y + b, 
            transform.position.z + c);
    }
}
