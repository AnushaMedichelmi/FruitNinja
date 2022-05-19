using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private GameObject splashReference;
    private Vector3 randomPos;
    private Text scoreReference;

    void Start()
    {
        randomPos = new Vector3(Random.Range(-1, 1), Random.Range(0.3f, 0.7f), Random.Range(-6.5f, -7.5f)); //To get the fruits in random positions in the game window
        scoreReference = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        /* Remove fruit if out of view */
        if (gameObject.transform.position.y < -36)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Line")
        {
            Camera.main.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

            Instantiate(splashReference, randomPos, transform.rotation);

            /* Update Score */

            scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
        }
    }
}
