using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerposistionCopyer : MonoBehaviour
{

    public Transform player;
    public Transform monster;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        monster.transform.position = player.transform.position + offset;

        if (!Input.GetKey(KeyCode.W))
        {
            offset.z -= 0.01f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            offset.z = 20;
        }


    }
}
