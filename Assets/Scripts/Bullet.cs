/*****************************************************************************
// File Name : Bullet.cs
// Author : Evan J. Daly
// Creation Date : August 24, 2024
//
// Brief Description : Movement of the Bullets
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 force;
    private Rigidbody2D rb;
    private float rng;
    private Vector3 vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector3(750, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(force * Time.deltaTime);
        rng = Random.Range(-5, 6);
        vertical = new Vector3(0, rng * 25, 0);
        rb.AddForce(vertical * Time.deltaTime);
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}
