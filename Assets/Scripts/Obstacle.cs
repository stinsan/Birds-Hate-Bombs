using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject effect;
    public GameObject explosionSound;
    private Shake shake;

    public int damage = 1;
    public float speed;

    private float timeElapsed = 0;

    public float speedMultiplierCoefficient;
    private float speedMultiplier = 1;

    private void Start() {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update() {
        timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
        speedMultiplier = 1 + (speedMultiplierCoefficient * timeElapsed);

        transform.Translate(Vector2.left * (speed * speedMultiplier) * Time.deltaTime);

        Debug.Log("Speed: " + (speed * speedMultiplier).ToString());
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            shake.CamShake(); // Camera shake on collision with player

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("BombHit");

            Instantiate(effect, transform.position, Quaternion.identity); // Explosion particle effects on collision with player

            Instantiate(explosionSound, transform.position, Quaternion.identity); // Explosion sound on collision with player

            other.GetComponent<PlayerController>().health -= damage;
            //Debug.Log("Health = " + other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
