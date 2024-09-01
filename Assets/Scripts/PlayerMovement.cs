using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        //Checks when bullets can be shot. Shooting is true when the player has the spacebar down. ShotAvaiable is true
        //when a bullet has been fired and enough time has passed to fire the next bullet.
        if (shooting && shotAvailable)
        {
            StartCoroutine(BulletFired());
        }
    }

    public void OnMovement(InputValue inputVector)
    {
        pMovement = inputVector.Get<float>();
    }

    //Checks if the shooting button is pressed or not.
    public void OnShoot()
    {
        shooting = true;
    }

    public void OnShootFinish()
    {
        shooting = false;
    }

    //Fires bullet and explosion at location of tank. Waits .35 seconds before next shot can be fired.
    IEnumerator BulletFired()
    {
        shotAvailable = false;
        Vector3 spawnLocation = new Vector3(transform.position.x + .5f, transform.position.y + .25f, -1);
        Instantiate(explosion, spawnLocation, Quaternion.identity);
        Instantiate(bullet, spawnLocation, Quaternion.identity);
        yield return new WaitForSeconds(.35f);
        shotAvailable = true;
    }
}
