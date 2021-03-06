using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanGesture : MonoBehaviour
{
    public GameObject prefab;

    public GameObject particle;
    public Text scoretext;
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            //We transform the touch position into word space from screen space and store it.
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            
            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;


                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
                if (touchedObject.tag == "Fruit")
                {
                    Destroy(touchedObject);
                    score = score + 1;
                    scoretext.GetComponent<Text>().text = score.ToString();
                    GameObject temp = Instantiate(prefab, touchedObject.transform.position, Quaternion.identity);
                    Destroy(temp, 1f);
                }
                else if (touchedObject.tag == "Bomb")
                {
                    Destroy(touchedObject);
                    score = score - 1;
                    scoretext.GetComponent<Text>().text = score.ToString();
                    GameObject temp = Instantiate(particle, touchedObject.transform.position, Quaternion.identity);
                    Destroy(temp, 1f);
                }

            }
        }
    }


}
