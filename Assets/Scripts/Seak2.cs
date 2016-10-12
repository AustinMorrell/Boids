using UnityEngine;
using System.Collections.Generic;

public class Seak2 : MonoBehaviour {

    [SerializeField]
    private List<Box> m_Piviots = new List<Box>();

    [SerializeField]
    private Vector3 m_Velocity;
    [SerializeField]
    private Vector3 m_Movement;

    [SerializeField]
    private float m_MovementFactor = 1f;

    [SerializeField]
    private float m_Mass = 1f;

    void Start()
    {
        for (int i = 0; i < FindObjectsOfType<Box>().Length; i++)
        {
            m_Piviots.Add(FindObjectsOfType<Box>()[i]);
        }
    }

    void Update()
    {
        foreach (Box box in m_Piviots)
        {
            m_MovementFactor = Mathf.Clamp(50f - Vector3.Distance(box.transform.position, transform.position), 0f, 50f);
            m_Movement = (box.transform.position - transform.position) * m_MovementFactor;
            m_Movement = m_Movement.normalized;
            m_Velocity += m_Movement / m_Mass;
        }
        transform.position += m_Velocity * Time.deltaTime;
    }
}
