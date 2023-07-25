using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementScript : MonoBehaviour
{
    public GameObject gameControllerObject;
    public Sprite[] BackGrounds = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerObject.GetComponent<GameController>().wave <= 1) { GetComponent<SpriteRenderer>().sprite = BackGrounds[0]; }
        if (gameControllerObject.GetComponent<GameController>().wave == 3) { GetComponent<SpriteRenderer>().sprite = BackGrounds[1]; }
        if (gameControllerObject.GetComponent<GameController>().wave == 5) { GetComponent<SpriteRenderer>().sprite = BackGrounds[2]; }

        if (transform.position.y < -10.5f) { transform.position = new Vector3(transform.position.x, +10.5f, transform.position.z); }
    }
}
