using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject[] gemSounds;

    public string gemColor;

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

        int randGemSounds = Random.Range(0, 3);
        Instantiate(gemSounds[randGemSounds], transform.position, Quaternion.identity); // Coin sound on collision with player

        if (other.CompareTag("Player")) {

            if (gemColor.Equals("green")) {
                other.GetComponent<PlayerController>().gemScore += 500;
            }
            else if (gemColor.Equals("orange")) {
                other.GetComponent<PlayerController>().gemScore += 1000;
            }

            Destroy(gameObject);
        }
    }
}
