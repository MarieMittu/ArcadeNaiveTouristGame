using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }

    }
}
