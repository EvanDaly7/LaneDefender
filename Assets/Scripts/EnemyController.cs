/*****************************************************************************
// File Name : EnemyController.cs
// Author : Evan J. Daly
// Creation Date : August 25, 2024
//
// Brief Description : Movement of the enemies
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject snake;
    [SerializeField] GameObject slime;
    [SerializeField] GameObject gastropod;
    private int rng;
    private float waitTime;
    private bool spawnEnemy = true;
    private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemy)
        {
            StartCoroutine(EnemyCreation());
        }
    }

    IEnumerator EnemyCreation()
    {
        spawnEnemy = false;
        rng = Random.Range(0, 3);
        switch(rng)
        {
            case 0:
                rng = Random.Range(-3, 2);
                spawnLocation = new Vector3(9.9f, rng, 0);
                Instantiate(snake, spawnLocation, Quaternion.identity);
                break;
            case 1:
                rng = Random.Range(-3, 2);
                spawnLocation = new Vector3(9.4f, rng, 0);
                Instantiate(slime, spawnLocation, Quaternion.identity);
                break;
            case 2:
                rng = Random.Range(-3, 2);
                spawnLocation = new Vector3(9.5f, rng, 0);
                Instantiate(gastropod, spawnLocation, Quaternion.identity);
                break;
        }
        yield return new WaitForSeconds(waitTime);
        waitTime = waitTime * .99f;
        spawnEnemy = true;
    }
}
