using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 force;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector3(750, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Moves bullet and kills it when it goes offscreen.
        rb.AddForce(force * Time.deltaTime);
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}
