using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public float speed;


    void OnTriggerStay(Collider other)
    {
        // passedThrough = true;
        //  other.GetComponent<Rigidbody>().AddForce(Vector3.up * 12, ForceMode.Acceleration);

        if (other.gameObject.name == "Enemy")
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
