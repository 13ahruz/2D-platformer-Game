using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isGrounded;
    private bool jumped;
    [SerializeField]
    private float speed = 0.2f;
    Rigidbody2D rb;
    [SerializeField]
    ParticleSystem death;
    private int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreText;
    AudioSource audioS;
    [SerializeField]
    AudioClip coinClip;
    [SerializeField]
    AudioClip destroyClip;
    [SerializeField]
    FloatingJoystick joys;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        scoreText.text = ("Score: " + score);
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            isGrounded = false;
        }

        transform.position += Vector3.right * 2 * Time.fixedDeltaTime;

        /*if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 7f, ForceMode2D.Impulse);
            jumped = true;
        }*/
        if (jumped)
        {
            speed = 0.15f;
        }
        else
        {
            speed = 0.2f;
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
            jumped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.transform.CompareTag("ObstacleGround"))
        {
            jumped = false;

        }*/

        if (other.transform.CompareTag("Coin"))
        {
            StartCoroutine(hideMesh(other.gameObject));
            score += 1;
        }

        if (other.transform.CompareTag("Obstacle"))
        {
            AudioSource.PlayClipAtPoint(destroyClip, transform.position);
            GetComponent<SpriteRenderer>().enabled = false;
            death.Play();
            Destroy(gameObject, 1f);
        }


        IEnumerator hideMesh(GameObject other)
        {
            other.SetActive(false);
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            yield return new WaitForSeconds(8f);
            other.SetActive(true);
        }

    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 7f, ForceMode2D.Impulse);
        jumped = true;
    }
}
