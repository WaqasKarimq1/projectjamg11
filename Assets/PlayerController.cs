using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject HealthBar;
    public GameObject GameControllerObject;
    public GameObject PlayerShield;
    public GameObject Explosion;

    public Sprite[] sprites = new Sprite[3];

    public AudioSource audioSource;
    public AudioClip[] Sounds = new AudioClip[4];

    public TextMeshProUGUI healthLevelText;
    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI fireRateLevelText;

    public TextMeshProUGUI healthCostText;
    public TextMeshProUGUI damageCostText;
    public TextMeshProUGUI fireRateCostText;

    bool canFire = true;
    bool invincible = false;

    float maxHealth = 10f;
    float health = 10f;
    public float damage = 1f;
    float fireRate = 1f;

    int healthLevel = 0;
    int damageLevel = 0;
    int fireRateLevel = 0;

    float vertSpeed = 0;
    float horzSpeed = 0;
    float maxVertSpeed = 8f;
    float maxHorzSpeed = 8f;
    float acceleration = 8f;
    float decceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canFire = true;
        maxHealth = 10f;
        health = 10f;
        damage = 1f;
        fireRate = 1f;
        healthLevel = 0;
        damageLevel = 0;
        fireRateLevel = 0;
        healthLevelText.text = "Health LVL: " + healthLevel;
        healthCostText.text = "Cost: " + (200 + 50 * healthLevel);
        damageLevelText.text = "Damage LVL: " + damageLevel;
        damageCostText.text = "Cost: " + (200 + 50 * damageLevel);
        fireRateLevelText.text = "Fire Rate LVL: " + fireRateLevel;
        fireRateCostText.text = "Cost: " + (200 + 50 * fireRateLevel);
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        canFire = true;
        maxHealth = 10f;
        health = 10f;
        damage = 1f;
        fireRate = 1f;
        healthLevel = 0;
        damageLevel = 0;
        fireRateLevel = 0;
        healthLevelText.text = "Health LVL: " + healthLevel;
        healthCostText.text = "Cost: " + (200 + 50 * healthLevel);
        damageLevelText.text = "Damage LVL: " + damageLevel;
        damageCostText.text = "Cost: " + (200 + 50 * damageLevel);
        fireRateLevelText.text = "Fire Rate LVL: " + fireRateLevel;
        fireRateCostText.text = "Cost: " + (200 + 50 * fireRateLevel);
        invincible = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        PlayerShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) && canFire) { Fire(); }
        HealthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        
    }
    public void StartWave()
    {
        health = maxHealth;
        invincible = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        PlayerShield.SetActive(false);
    }
    public void Fire()
    {
        GameObject BulletShot = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        BulletShot.GetComponent<BulletScript>().damage = damage;
        canFire = false;
        audioSource.PlayOneShot(Sounds[0], GameControllerObject.GetComponent<GameController>().volume);
        StartCoroutine(ShootDelay());
    }
    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            audioSource.PlayOneShot(Sounds[1], GameControllerObject.GetComponent<GameController>().volume);
            StartCoroutine(DamageAnim());
            health -= damage;
            if (health <= 0)
            {
                Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                healthLevel = 0;
                damageLevel = 0;
                fireRateLevel = 0;
                maxHealth = 10f;
                health = 10f;
                this.damage = 1f;
                fireRate = 1f;
                GameControllerObject.GetComponent<GameController>().EndGame();
            }
        }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow)) { GetComponent<SpriteRenderer>().sprite = sprites[1]; }
        else if (Input.GetKey(KeyCode.LeftArrow)) { GetComponent<SpriteRenderer>().sprite = sprites[2]; }
        else { GetComponent<SpriteRenderer>().sprite = sprites[0]; }
        if (Input.GetKey(KeyCode.UpArrow) && vertSpeed < maxVertSpeed) 
        { 
            vertSpeed += acceleration * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.DownArrow) && vertSpeed > -maxVertSpeed) 
        { 
            vertSpeed -= acceleration * Time.deltaTime;
        }
        else 
        { 
            if (vertSpeed > 0) 
            { 
                vertSpeed -= acceleration * Time.deltaTime; 
            } 
            if (vertSpeed < 0) 
            { 
                vertSpeed += acceleration * Time.deltaTime; 
            } 
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        if (Input.GetKey(KeyCode.RightArrow) && horzSpeed < maxHorzSpeed)
        {
            horzSpeed += acceleration * Time.deltaTime; }
        else if (Input.GetKey(KeyCode.LeftArrow) && horzSpeed > -maxHorzSpeed)
        {
            horzSpeed -= acceleration * Time.deltaTime;
        }
        else 
        { 
            if (horzSpeed > 0) 
            { 
                horzSpeed -= acceleration * Time.deltaTime; 
            } 
            if (horzSpeed < 0) 
            { 
                horzSpeed += acceleration * Time.deltaTime; 
            } 
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        transform.position = new Vector3(transform.position.x + horzSpeed * Time.deltaTime, transform.position.y + vertSpeed * Time.deltaTime, 0 );

        if (transform.position.x >= 9.2f) { transform.localPosition = new Vector3(9.1f, transform.position.y, transform.position.z); horzSpeed = 0; }
        if (transform.position.x <= -9.2f) { transform.localPosition = new Vector3(-9.1f, transform.position.y, transform.position.z); horzSpeed = 0; }
        if (transform.position.y >= 5f) { transform.localPosition = new Vector3(transform.position.x, 4.9f, transform.position.z); vertSpeed = 0; }
        if (transform.position.y <= -5f) { transform.localPosition = new Vector3(transform.position.x, -4.9f, transform.position.z); vertSpeed = 0; }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    IEnumerator DamageAnim()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    

    public void IncreaseStat(string name)
    {
        if (name == "Health" && GameControllerObject.GetComponent<GameController>().points >= 200 + 50 * healthLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 200 + 50 * healthLevel; healthLevel += 1; maxHealth = 10f + 5f * healthLevel; health = maxHealth; }
        if (name == "Damage" && GameControllerObject.GetComponent<GameController>().points >= 200 + 50 * damageLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 200 + 50 * damageLevel; damageLevel += 1; damage = 1f + 1.5f * damageLevel; }
        if (name == "FireRate" && GameControllerObject.GetComponent<GameController>().points >= 200 + 50 * fireRateLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 200 + 50 * fireRateLevel; fireRateLevel += 1; fireRate = 1.5f / (1 + 0.2f * fireRateLevel); }

        healthLevelText.text = "Health LVL: " + healthLevel;
        healthCostText.text = "Cost: " + (200 + 50 * healthLevel);
        damageLevelText.text = "Damage LVL: " + damageLevel;
        damageCostText.text = "Cost: " + (200 + 50 * damageLevel);
        fireRateLevelText.text = "Fire Rate LVL: " + fireRateLevel;
        fireRateCostText.text = "Cost: " + (200 + 50 * fireRateLevel);
    }

    public void GetPowerUp(string PowerUpType)
    {
        if (PowerUpType == "RapidFire") { StartCoroutine(RapidFire()); }
        if (PowerUpType == "Shield") { PlayerShield.SetActive(true); }
        if (PowerUpType == "Invincible") { StartCoroutine(Invincible()); }
    }

    IEnumerator RapidFire()
    {
        fireRate = 0.1f;
        yield return new WaitForSeconds(4f);
        fireRate = 1.5f / (1 + 0.2f * fireRateLevel);
    }

    IEnumerator Invincible()
    {
        invincible = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(4f);
        invincible = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
