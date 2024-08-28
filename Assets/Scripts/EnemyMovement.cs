/*****************************************************************************
// File Name : EnemyMovement.cs
// Author : Evan J. Daly
// Creation Date : August 25, 2024
//
// Brief Description : Movement of the enemies
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] int startingSpeed;
    [SerializeField] int health;
    private int speed;
    private TextController textController;
    [SerializeField] GameObject explosion;
    private Vector3 spawnLocation;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speed = startingSpeed;
        textController = FindFirstObjectByType<TextController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            textController.LifeLoss();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            animator.SetTrigger("damaged");
            spawnLocation = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            Instantiate(explosion, spawnLocation, Quaternion.identity);
            health = health - 1;
            if (health < 1)
            {
                textController.ScoreIncrease();
                StartCoroutine(Damaged());
            }
            else
            {
                StartCoroutine(Damaged());
            }
            Destroy(collision.gameObject);
        }
        if (collision.name == "PlayerTank")
        {
            textController.LifeLoss();   
            Destroy(gameObject);
        }
    }

    IEnumerator Damaged()
    {
        speed = 0;
        yield return new WaitForSeconds(.15f);
        speed = startingSpeed;
    }

    IEnumerator Death()
    {
        speed = 0;
        animator.SetTrigger("damaged");
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
    }
}
