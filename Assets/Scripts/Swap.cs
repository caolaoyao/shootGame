using UnityEngine;
using System.Collections;

public class Swap : MonoBehaviour {
    float create_delay = 3f;
    float move_delay = 2f;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        create_delay -= Time.deltaTime;
        move_delay -= Time.deltaTime;

        if(create_delay <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            create_delay = 3f;
        }

        if (move_delay <= 0)
        {
            float y = Random.Range(6, -4);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
	}
}
