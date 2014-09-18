using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour {
    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);
    public float distance = 30.69f;
    private List<Transform> backgroundPart;
	// Use this for initialization
	void Start () {
        backgroundPart = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.renderer != null)
            {
                backgroundPart.Add(child);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < backgroundPart.Count; i++)
        {
            if (backgroundPart[i].transform.position.x < -distance)
            {
                backgroundPart[i].transform.position = new Vector3(distance, backgroundPart[i].transform.position.y, backgroundPart[i].transform.position.z);
            }

            backgroundPart[i].transform.Translate(Vector3.left * speed.x);
        }
	}
}
