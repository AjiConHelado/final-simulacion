using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveCollision : MonoBehaviour
{
    [SerializeField] GameObject nave;
    [SerializeField] GameObject cartel;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "misil")
        {

            nave.SetActive(false);
            cartel.SetActive(true);

        }
    }
}
