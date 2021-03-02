using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector2 circularMovementCenter;
    public float circularMovementRadius;
    public float circularMovementAngule;
    public float circularMovementRotationSpeed;
    public Explosion m_explosionPrefab;

    public int m_hp;
    public int m_max_hp;

    public static Target m_instance;

    // Start is called before the first frame update
    void Start()
    {
        m_instance = this;
        m_hp = m_max_hp = 10;
        circularMovementCenter = new Vector2(0f, 0f);
        circularMovementRadius = 1f;
        circularMovementAngule = 0f;
        circularMovementRotationSpeed = 30f * Mathf.PI /180 * Time.deltaTime; // radian

        // テキストの表示
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "enemy";
        meshRenderer.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        circularMovementAngule = (circularMovementAngule + circularMovementRotationSpeed) % 360;
        transform.position = new Vector2(Mathf.Sin(circularMovementAngule), Mathf.Cos(circularMovementAngule)) * circularMovementRadius + circularMovementCenter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(m_explosionPrefab, collision.transform.localPosition, Quaternion.identity);
        if (collision.gameObject.GetComponent<Bullet>())
        {
            var damage = collision.gameObject.GetComponent<Bullet>().damage;
            m_hp -= damage;
        }
    }
}
