using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class Sphere : MonoBehaviour
{
    private int force = 10;
    private int verticalForce = 4;
    public bool alive = true;
    private GameManagerScript GMS;
    private Respawn rsp;

    // Start is called before the first frame update
    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        rsp = GameObject.Find("Respawn").GetComponent<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;

        if (Input.GetKey(KeyCode.D))
            x -= force;
        if (Input.GetKey(KeyCode.A))
            x += force;

        int z = 0;

        if (Input.GetKey(KeyCode.W))
            z -= force;
        if (Input.GetKey(KeyCode.S))
            z += force;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.005f)
            GetComponent<Rigidbody>().AddForce(Vector3.up * verticalForce, ForceMode.Impulse);

        GetComponent<Rigidbody>().AddForce(x, 0, z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Danger" && GMS.coins < 2)
            gameObject.SetActive(false);
            rsp.alive = false;
    }
}
