using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
        transform.eulerAngles = new Vector3(0f, 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (Input.GetKey(KeyCode.W)) transform.Translate(0f, 1f * Time.deltaTime, 0f);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0f, -1f * Time.deltaTime, 0f);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-1f * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.D)) transform.Translate(1f * Time.deltaTime, 0f, 0f);
        //向き
        float angle_radian = (transform.eulerAngles.z + 90f) * Mathf.PI / 180;
        Vector2 forword = new Vector2(Mathf.Cos(angle_radian), Mathf.Sin(angle_radian));
        Vector2 toMouse = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        print($"{transform.eulerAngles}, {toMouse}, {forword}, {Vector2.SignedAngle(forword, toMouse)}");
        transform.Rotate(new Vector3(0f, 0f, 30f * Time.deltaTime * Mathf.Sign(Vector2.SignedAngle(forword, toMouse))));


    }

}
