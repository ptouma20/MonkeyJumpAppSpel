using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSK : MonoBehaviour
{
    float m_Speed;
    Rigidbody2D RG;
    void Start()
    {
        m_Speed = 70f;
        RG = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * m_Speed, Space.World);
        RG.velocity = new Vector2(-10f,-10f);
    }
}
