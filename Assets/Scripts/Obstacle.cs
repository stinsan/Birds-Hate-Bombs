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
    public float increaseSpeed = 0.5f;
    public float maxSpeed = 20;

    private void Start() {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update() {

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            shake.CamShake(); // Camera shake on collision with player

            Instantiate(effect, transform.position, Quaternion.identity); // Explosion particle effects on collision with player

            Instantiate(explosionSound, transform.position, Quaternion.identity); // Explosion sound on collision with player

            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log("Health = " + other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
