using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] Sounds = new AudioClip[2];
    int Hitpoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().volume;
        audioSource.PlayOneShot(Sounds[0]);
        Hitpoints = 3;
    }

    private void OnEnable()
    {
        Hitpoints = 3;
        audioSource.PlayOneShot(Sounds[0]);
        audioSource.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().volume;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(Sounds[1]);
            Hitpoints -= 1;
            if (Hitpoints <= 0) { gameObject.SetActive(false); }
        }
    }
}
