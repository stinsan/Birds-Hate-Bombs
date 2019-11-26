using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject thing;

    // Start is called before the first frame update
    void Start() {
        Instantiate(thing, transform.position, Quaternion.identity);
    }

}
