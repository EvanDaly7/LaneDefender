using System.Collections;
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
    [SerializeField] AudioSource audioClip;
    private TextController textController;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 2f;
        Time.timeScale = 1.0f;
        audioClip.pitch = Time.timeScale;
        textController = FindAnyObjectByType<TextController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawns an enemy when spawnEnemy is true.
        if (spawnEnemy)
        {
            StartCoroutine(EnemyCreation());
        }
    }

    IEnumerator EnemyCreation()
    {
        //Sets spawnEnemy to false so only 1 bug spawns at a time.
        spawnEnemy = false;
        //Randomly choses from list of enemies.
        rng = Random.Range(0, 3);
        switch(rng)
        {
            case 0:
                rng = Random.Range(-3, 2);
                //Choses a random lane to spawn in.
                spawnLocation = new Vector3(9.9f, rng, 0);
                Instantiate(snake, spawnLocation, Quaternion.identity);
                break;
            case 1:
                rng = Random.Range(-3, 2);
                spawnLocation = new Vector3(9.4f, rng, 0);
                Instantiate(slime, spawnLocation, Quaternion.identity);
                //The Slime and Gastropod enemy have a longer wait time before the next enemy spawns for game balance.
                yield return new WaitForSeconds(.35f);
                break;
            case 2:
                rng = Random.Range(-3, 2);
                spawnLocation = new Vector3(9.5f, rng, 0);
                Instantiate(gastropod, spawnLocation, Quaternion.identity);
                yield return new WaitForSeconds(1.05f);
                break;
        }
        //Waits a set amount of time before setting spawnEnemy to true so a new bug spawns.
        yield return new WaitForSeconds(waitTime);
        if (textController.lives > 0)
        {
            //Decreases amount of waitTime until it hits a limit to increase difficulty.
            if (waitTime > 1.25f)
            {
                waitTime = waitTime * .99f;
            }
            else if (Time.timeScale < 2.5)
            {
                //Once waitTime is at its max difficulty, the game speed increases until a max limit to increase the difficulty.
                Time.timeScale *= 1.01f;
                //Music also increases at the same speed as the game.
                audioClip.pitch = Time.timeScale;
            }
        }
        spawnEnemy = true;
    }
}
