using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionDestroyed());
    }

    //Destroys explosion once .2 seconds have passed
    IEnumerator ExplosionDestroyed()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
