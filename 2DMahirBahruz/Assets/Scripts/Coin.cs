using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    AudioSource audioS;
    AudioClip aud;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(hideMesh());
        }
    }

    IEnumerator hideMesh()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);

    }*/
}
