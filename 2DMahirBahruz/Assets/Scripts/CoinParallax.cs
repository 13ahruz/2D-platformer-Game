using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParallax : MonoBehaviour
{
    [SerializeField]
    Transform cameraPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraPos.transform.position.x >= transform.position.x + 25)
        {
            transform.position = new Vector3(transform.position.x + 50, transform.position.y, transform.position.z);

        }
    }
}
