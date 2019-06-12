using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    public Light corridorLight;


    private void Start()
    {
        corridorLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.W))
        {

           

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            corridorLight.gameObject.SetActive(true);
            Debug.Log("Player Touched Trigger");

        }
        if (other.name == "Monster")
        {
            corridorLight.gameObject.SetActive(true);
            Debug.Log("Monster TouchedTrigger");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {

            corridorLight.gameObject.SetActive(false);

        }
        if (other.name == "Monster")
        {
            corridorLight.gameObject.SetActive(false);
            Debug.Log("Monster TouchedTrigger");
        }
    }
}
