using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject gameControllerObject;
    public GameObject Shield;
    public GameObject Bullet;
    public GameObject Explosion;
    public GameObject[] PowerUps = new GameObject[3];
    public Sprite[] ShipType = new Sprite[3];

    AudioSource audioSource;

    public string enemyType;
    float HitPoints = 3;
    public float damage;
    float pointsOnDeath;
    float pointsPerHit;

    int moveTimes = 4;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 0, 180);
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        audioSource.volume = gameControllerObject.GetComponent<GameController>().volume;
        //GetComponent<Rigidbody2D>().AddForce(transform.up * -50f);
        if (enemyType == "BasicEnemy")
        {
            HitPoints = 3f * gameControllerObject.GetComponent<GameController>().wave;
            damage = 1f * gameControllerObject.GetComponent<GameController>().wave;
            pointsPerHit = 10f;
            pointsOnDeath = 50f;
            gameObject.GetComponent<SpriteRenderer>().sprite = ShipType[0];
        }

        if (enemyType == "ShieldedEnemy") 
        {
            HitPoints = 1f * gameControllerObject.GetComponent<GameController>().wave;
            damage = 2f * gameControllerObject.GetComponent<GameController>().wave;
            pointsPerHit = 15f;
            pointsOnDeath = 75f;
            Shield.SetActive(true);
            Shield.GetComponent<ShieldScript>().hitPoints = 3f * gameControllerObject.GetComponent<GameController>().wave;
            gameObject.GetComponent<SpriteRenderer>().sprite = ShipType[1];
        }

        if (enemyType == "MovingEnemy")
        {
            HitPoints = 2f * gameControllerObject.GetComponent<GameController>().wave;
            damage = 3f * gameControllerObject.GetComponent<GameController>().wave;
            pointsPerHit = 20f;
            pointsOnDeath = 100f;
            gameObject.GetComponent<SpriteRenderer>().sprite = ShipType[2];
            StartCoroutine(SideMovement());
        }
        StartCoroutine(SpawnIn());
        
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6f) { GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemyDied(); Destroy(gameObject); }
    }

    IEnumerator SpawnIn()
    {
        for (int i = 0; i <= 100; i++) 
        { 
            transform.position = new Vector3(transform.position.x, 5 - (i * 0.01f), transform.position.z); 
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(Move());
        
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 100; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        moveTimes -= 1;
        if (moveTimes > 0) { StartCoroutine(Move()); }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);
        GameObject BulletShot = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
        BulletShot.GetComponent<EnemyBulletScript>().damage = damage;
        StartCoroutine(Shoot());
    }

    IEnumerator SideMovement()
    {
        for(int i = 0; i < 100; i++)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 100; i++)
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(SideMovement());
    }
    public void TakeDamage(float damage)
    {
        audioSource.Play();
        StartCoroutine(DamageAnim());
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            if (Random.Range(0, 100) >= 90) 
            {
                Instantiate(PowerUps[Random.Range(0, 3)], new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            }
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().points += pointsOnDeath;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemyDied();
            Destroy(gameObject);
        }
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().points += pointsPerHit;
    }

    IEnumerator DamageAnim()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        { 
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(HitPoints);
            TakeDamage(HitPoints);
            Destroy(gameObject);
        }
    }
}
