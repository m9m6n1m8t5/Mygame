using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        duration = 5f;
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
