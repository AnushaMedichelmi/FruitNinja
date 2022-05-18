using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject appleReference;
    private Vector3 throwForce;

    void Start()
    {
        throwForce = new Vector3(0, 10, 0);
        InvokeRepeating("SpawnFruit", 0.5f, 6);
    }

    void SpawnFruit()
    {
        for (byte i = 0; i < 4; i++)
        {
            GameObject fruit = Instantiate(appleReference, new Vector3(Random.Range(-6.6f, 6.6f), Random.Range(-8.0f, -1.0f), 0.0f), Quaternion.identity) as GameObject;
            fruit.GetComponent<Rigidbody2D>().AddForce(throwForce, ForceMode2D.Impulse);
        }
    }
}
