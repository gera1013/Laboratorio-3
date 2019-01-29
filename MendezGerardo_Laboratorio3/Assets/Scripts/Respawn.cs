using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject Player;
    public bool alive = true;
    private Vector3 startPoint;

    private void Start()
    {
        Player = GameObject.Find("Ball");
        startPoint = Player.transform.position;
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return) && alive == false)
            Player.transform.position = startPoint;
            Player.SetActive(true);
            alive = true;
    }
}
