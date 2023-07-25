using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using TMPro;
using System.Diagnostics.Contracts;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    public GameObject BossObject;
    public GameObject UpgradeMenu;
    public GameObject GameFinishedScreen;
    public GameObject GameOverScreen;
    public GameObject DialogBox;
    public Slider VolumeChanger;
    public TextMeshProUGUI pointsText;

    public AudioSource audioSource;
    public AudioClip[] Sounds = new AudioClip[5];

    bool isPlaying = false;
    public float volume = 0.5f;
    public float points = 0;
    public int wave = 0;
    public int enemiesLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //playerObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + points;
        audioSource.volume = volume;
    }

    public void MainMenu()
    {
        audioSource.clip = Sounds[0];
        audioSource.Play();
    }

    public void MenuButtonClick()    { audioSource.PlayOneShot(Sounds[6]); }

    public void ChangeVolume()
    {
        volume = VolumeChanger.value;
    }
    public void Begin()
    {
        audioSource.PlayOneShot(Sounds[5]);
        StartCoroutine(StartGame());
    }
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        isPlaying = true;
        DialogBox.SetActive(true);
        GetComponent<DialogControllerScript>().PlayCutScene(0);
    }
    public void NextWave()
    {
        wave += 1;
        playerObject.GetComponent<PlayerController>().StartWave();
        audioSource.clip = Sounds[1];
        audioSource.Play();
        audioSource.PlayOneShot(Sounds[7]);
        if (wave == 5) { audioSource.clip = Sounds[8]; audioSource.Play(); }
        StartCoroutine(SpawnEnemies(wave));
    }

    public void FinishGame()
    {
        isPlaying = false;
        UpgradeMenu.SetActive(false);
        playerObject.SetActive(false);
        GameObject[] Enemies = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemies != null)
        {
            foreach (GameObject Enemy in Enemies) { Destroy(Enemy); }
        }
        StartCoroutine(FinishGamePart2());
    }

    IEnumerator FinishGamePart2()
    {
        audioSource.PlayOneShot(Sounds[3]);
        audioSource.clip = Sounds[0];
        audioSource.Play();
        yield return new WaitForSeconds(10f);
        GameFinishedScreen.SetActive(true);
        wave = 0;
        enemiesLeft = 0;
        points = 0;
    }

    public void EndGame()
    {
        isPlaying = false;
        GameObject[] AllEnemies = new GameObject[enemiesLeft];
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in AllEnemies) { Destroy(Enemy); }
        if (wave == 5) { Destroy(GameObject.FindGameObjectWithTag("Boss").gameObject); }
        playerObject.SetActive(false);
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        audioSource.PlayOneShot(Sounds[4]);
        yield return new WaitForSeconds(2f);
        GameOverScreen.SetActive(true);
        wave = 0;
        enemiesLeft = 0;
        points = 0;
    }

    public void RandomSpawn()
    {
        int x = Random.Range(0, 3);
        if (x == 0) 
        { 
            GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(playerObject.transform.position.x, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
        }
        if (x == 1)
        {
            GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(playerObject.transform.position.x, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldEnemy";
        }
        if (x == 2)
        {
            GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(playerObject.transform.position.x, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
        }
        enemiesLeft++;
    }

    IEnumerator SpawnEnemies(int wave)
    {
        if (wave == 1)
        {
            enemiesLeft = 10;
            for (int i = 0; i < 5; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 5, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                }
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-6 + 3.5f * i, 5f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                }
            }
        }
        if (wave == 2)
        {
            DialogBox.SetActive(true);
            GetComponent<DialogControllerScript>().PlayCutScene(6);
            yield return new WaitForSeconds(12f);
            enemiesLeft = 14;
            for (int i = 0; i < 5; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                }
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 3; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-5 + 3.3f * i, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                }
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {

                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                }
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 1; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                }
            }
        }
        if (wave == 3)
        {
            DialogBox.SetActive(true);
            GetComponent<DialogControllerScript>().PlayCutScene(7);
            yield return new WaitForSeconds(12f);
            enemiesLeft = 8;
            for (int i = 0; i < 5; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (isPlaying)
                {
                    GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-5 + 3.3f * i, 4f, 0f), transform.rotation);
                    EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                }
            }
            yield return new WaitForSeconds(10f);
        }
        if (wave == 4)
        {
            DialogBox.SetActive(true);
            GetComponent<DialogControllerScript>().PlayCutScene(8);
            yield return new WaitForSeconds(10f);
            enemiesLeft = 15;
            GameObject EnemySpawned;
            if (isPlaying)
            {
                EnemySpawned = Instantiate(enemyObject, new Vector3(-7, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(-3.5f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(3.5f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(7, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
            
                yield return new WaitForSeconds(10f);
            }
            if (isPlaying)
            {
                EnemySpawned = Instantiate(enemyObject, new Vector3(-8, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(-4f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(4f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(8, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                yield return new WaitForSeconds(10f);
            }
            if (isPlaying)
            {
                EnemySpawned = Instantiate(enemyObject, new Vector3(-7, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(-3.5f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(3.5f, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                EnemySpawned = Instantiate(enemyObject, new Vector3(7, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            }
        }
        if (wave == 5)
        {
            DialogBox.SetActive(true);
            GetComponent<DialogControllerScript>().PlayCutScene(9);
            yield return new WaitForSeconds(15f);
            Instantiate(BossObject, new Vector3(0, 4f, 0f), transform.rotation);
        }
        //StartCoroutine(SpawnEnemies());
    }

    public void QuitGame()
    {
      //UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
    }

    public void EnemyDied()
    {
        enemiesLeft--;
        if (enemiesLeft <= 0 && wave != 5) { DialogBox.SetActive(true); GetComponent<DialogControllerScript>().PlayCutScene(wave); audioSource.clip = Sounds[0]; audioSource.Play(); }
    }
}
