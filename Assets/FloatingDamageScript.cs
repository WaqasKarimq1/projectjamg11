using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingDamageScript : MonoBehaviour
{
    public TextMeshProUGUI x;
    public float DamageTaken;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 0, transform.position.z);
        x.text = DamageTaken.ToString();
        StartCoroutine(ShowDamage());
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector3(0, 0, transform.position.z);
        x.text = DamageTaken.ToString();
        StartCoroutine(ShowDamage());
    }

    IEnumerator ShowDamage()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 150f);
        x.text = DamageTaken.ToString();
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = new Vector3(0, 0, transform.position.z);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
