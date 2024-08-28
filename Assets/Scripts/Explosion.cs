/*****************************************************************************
// File Name : Explosion.cs
// Author : Evan J. Daly
// Creation Date : August 25, 2024
//
// Brief Description : Spawning of the Explosion for the bullets.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionDestroyed());
    }

    IEnumerator ExplosionDestroyed()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
