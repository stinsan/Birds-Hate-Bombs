using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject[] gemSounds;
    public GameObject effect;

    public float speed;

    private float timeElapsed = 0;

    public float speedMultiplierCoefficient;
    private float speedMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
        speedMultiplier = 1 + (speedMultiplierCoefficient * timeElapsed);

        transform.Translate(Vector2.left * (speed * speedMultiplier) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            int randGemSounds = Random.Range(0, gemSounds.Length);
            Instantiate(gemSounds[randGemSounds], transform.position, Quaternion.identity); // Random coin sound on collision with player

            Instantiate(effect, transform.position, Quaternion.identity); // Gem particle effect on collision with player

            other.GetComponent<PlayerController>().gemScore += 500; // +500 to score when gem collected

            Destroy(gameObject);
        }
    }
}
