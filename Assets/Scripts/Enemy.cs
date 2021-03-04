using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 circularMovementCenter;
    public float circularMovementRadius;
    public float circularMovementAngule;
    public float circularMovementRotationSpeed;
    public Explosion m_explosionPrefab;

    private int m_hp;
    private int m_max_hp;
    public int Hp
    {
        get
        {
            return m_hp;
        }
    }
    public int MaxHp
    {
        get
        {
            return m_max_hp;
        }
    }

    private void Awake()
    {
        m_hp = m_max_hp = 10;
        circularMovementCenter = new Vector2(0f, 0f);
        circularMovementRadius = 1f;
        circularMovementAngule = 0f;
        circularMovementRotationSpeed = 30f * Mathf.PI / 180 * Time.deltaTime; // radian
    }
    // Start is called before the first frame update
    void Start()
    {
        // テキストの表示
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "enemy";
        meshRenderer.sortingOrder = 0;
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
            Damage(damage);
        }
    }

    void Damage(int damage)
    {
        m_hp -= damage;
        if (m_hp <= 0) Destroy(gameObject);            
    }
}
