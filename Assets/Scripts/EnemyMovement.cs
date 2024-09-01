using System.Collections;
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
    [SerializeField] AudioSource enemyDamaged;
    [SerializeField] AudioSource enemyKilled;

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
        //Moves Bugs. Despawn off screen and makes player lose a life.
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            textController.LifeLoss();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Touching a bullet plays the damaged animation, sets an explosion at the location and causes enemy to lose 1 health point.
        if (collision.tag == "Bullet")
        {
            animator.SetTrigger("damaged");
            spawnLocation = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            Instantiate(explosion, spawnLocation, Quaternion.identity);
            health = health - 1;
            //If enemy is out of health, it will despawn.
            if (health < 1)
            {
                textController.ScoreIncrease();
                StartCoroutine(Death());
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

    //When bug is hit by bullet
    IEnumerator Damaged()
    {
        enemyDamaged.Play();
        speed = 0;
        yield return new WaitForSeconds(.15f);
        speed = startingSpeed;
    }

    //When bug is killed by bullet
    IEnumerator Death()
    {
        enemyKilled.Play();
        speed = 0;
        animator.SetTrigger("damaged");
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
    }
}
