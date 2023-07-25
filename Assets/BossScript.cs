using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float HitPoints = 500f;
    public float pointsPerHit = 25f;
    public float pointsOnDeath = 500f;
    public bool RapidShootingEnabled = false;
    public bool ShootingEnabled = false;
    public GameObject Exlposion;
    public GameObject Bullet;

    AudioSource audioSource;

    public AudioClip[] Sounds = new AudioClip[3];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().volume;
        transform.rotation = Quaternion.Euler(0, 0, 180);
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpinShot());
        StartCoroutine(ShootType());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootType()
    {
        if (RapidShootingEnabled) { Shoot(); yield return new WaitForSeconds(0.4f); }
        else if (ShootingEnabled) { Shoot(); yield return new WaitForSeconds(0.8f); }
        Shoot();
        StartCoroutine(ShootType());
    }
    void Shoot()
    {
        GameObject BulletShot = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
        BulletShot.GetComponent<EnemyBulletScript>().damage = 5;
    }
    IEnumerator SpinShot()
    {
        yield return new WaitForSeconds(2f);
        ShootingEnabled = false;
        RapidShootingEnabled = true;
        for (int i = 0; i < 360; i++)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + i);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(MoveShot());
    }

    IEnumerator MoveShot()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
        yield return new WaitForSeconds(2f);
        ShootingEnabled = true;
        RapidShootingEnabled = false;
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(0, 3);
            if (x == 0)
            {
                while (transform.position.x < -7f) 
                { 
                    transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, 0);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else if (x == 1)
            {
                while (transform.position.x < 7f)
                {
                    transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, 0);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else if (x == 2)
            {
                while (transform.position.x < 0f)
                {
                    transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                while (transform.position.x > 0f)
                {
                    transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, 0);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            ShootingEnabled = false;
            RapidShootingEnabled = true;
            yield return new WaitForSeconds(2f);
        }
        StartCoroutine(SpinShot());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RandomSpawn();
        StartCoroutine(SpawnEnemy());
    }

    public void TakeDamage(float damage)
    {
        audioSource.PlayOneShot(Sounds[0]);
        StartCoroutine(DamageAnim());
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            Instantiate(Exlposion, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().points += pointsOnDeath;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DialogBox.SetActive(true);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogControllerScript>().PlayCutScene(5);
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
}
