/*****************************************************************************
// File Name : PlayerMovement.cs
// Author : Evan J. Daly
// Creation Date : August 23, 2024
//
// Brief Description : Movement of the Tank and Spawns Bullets
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedValue;
    private float pMovement;
    private Rigidbody2D rb;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject explosion;
    private bool shooting;
    private bool shotAvailable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shotAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, pMovement * speedValue, -1f);
        if (transform.position.y > 1.16)
        {
            transform.position = new Vector2(transform.position.x, 1.16f);
        }
        if (transform.position.y < -3.17)
        {
            transform.position = new Vector2(transform.position.x, -3.17f);
        }
        if (shooting && shotAvailable)
        {
            StartCoroutine(BulletFired());
        }
    }

    public void OnMovement(InputValue inputVector)
    {
        pMovement = inputVector.Get<float>();
    }


    public void OnShoot()
    {
        shooting = true;
    }

    public void OnShootFinish()
    {
        shooting = false;
    }

    IEnumerator BulletFired()
    {
        shotAvailable = false;
        Vector3 spawnLocation = new Vector3(transform.position.x + .5f, transform.position.y + .25f, -1);
        Instantiate(bullet, spawnLocation, Quaternion.identity);
        Instantiate(explosion, spawnLocation, Quaternion.identity);
        yield return new WaitForSeconds(.35f);
        shotAvailable = true;
        
    }
}
