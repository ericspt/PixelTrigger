using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public Camera cameraObject;

    public float force = 0.1f;

    public float currentPoints = 0f;

    public Text score;

    public ParticleSystem playerExplosion;

    public ParticleSystem pointExplosion;

    public Animator textAnimation;

    public Animator cameraShake;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentPoints = 0f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 cast = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit;

            hit = Physics2D.Raycast(new Vector2(cast.x, cast.y), Vector2.zero);

            if (hit.transform.tag == "Points")
            {
                StartCoroutine(TextAnimation());
                currentPoints++;
                pointExplosion.transform.position = hit.transform.position;
                pointExplosion.Play();
                Destroy(hit.transform.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Out of bounds
        if (transform.position.y > 12)
        {
            Die();
        }

        score.text = currentPoints.ToString();
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Lava")
        {
            Die();
        }
        else if (collision.transform.tag == "Enemy")
        {
            Die();
        }
        else if (collision.transform.tag == "Points")
        {
            pointExplosion.transform.position = collision.transform.position;
            pointExplosion.Play();
            StartCoroutine(TextAnimation());
            currentPoints++;
        }
    }

    private void Die()
    {
        playerExplosion.transform.position = gameObject.transform.position;
        playerExplosion.Play();
        StartCoroutine(CameraShake());
        Destroy(gameObject);
    }

    IEnumerator TextAnimation()
    {
        textAnimation.SetBool("GotPoints", true);
        yield return new WaitForSeconds(0.1f);
        textAnimation.SetBool("GotPoints", false);
    }

    IEnumerator CameraShake()
    {
        cameraShake.SetBool("GotPoint", true);
        yield return new WaitForSeconds(0.08f);
        cameraShake.SetBool("GotPoint", false);
    }
}
