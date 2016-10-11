using UnityEngine;
using System.Collections;

public class Seak : MonoBehaviour {

    public Vector3 m_Force;
    public int m_Mass;
    Vector3 m_Velocity;

    void FixedUpdate()
    {
        m_Velocity = ((m_Force / m_Mass) * Time.deltaTime);
    }

    void LateUpdate()
    {
        transform.position += m_Velocity;
    }
}
