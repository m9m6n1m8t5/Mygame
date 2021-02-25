using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject bullet;

    Camera cam;
    Renderer _renderer;
    float speed;
    float rotationSpeed;
    float radius;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
        speed = 1f;
        rotationSpeed = 60f;
        _renderer = GetComponent<SpriteRenderer>();
        radius = _renderer.bounds.size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        float angle_radian = (transform.eulerAngles.z + 90f) * Mathf.PI / 180;
        Vector2 forword = new Vector2(Mathf.Cos(angle_radian), Mathf.Sin(angle_radian));
        Vector2 toMouse = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        // print($"{transform.eulerAngles}, {toMouse}, {forword}, {Vector2.SignedAngle(forword, toMouse)}");

        //移動
        if (toMouse.magnitude > 30f) transform.Translate(0f, speed * Time.deltaTime, 0f);

        //向き
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * Mathf.Sign(Vector2.SignedAngle(forword, toMouse))));

        //弾の発射
        if (Input.GetMouseButtonDown(0)) Instantiate(bullet, transform.position + new Vector3(forword.x, forword.y, 0f) * radius, transform.rotation);
        
        //キー入力
        //if (Input.GetKey(KeyCode.W)) transform.Translate(0f, 1f * Time.deltaTime, 0f);
        //if (Input.GetKey(KeyCode.S)) transform.Translate(0f, -1f * Time.deltaTime, 0f);
        //if (Input.GetKey(KeyCode.A)) transform.Translate(-1f * Time.deltaTime, 0f, 0f);
        //if (Input.GetKey(KeyCode.D)) transform.Translate(1f * Time.deltaTime, 0f, 0f);



    }

}
