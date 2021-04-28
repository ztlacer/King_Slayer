using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldScript : MonoBehaviour
{
    public StatObject statObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            statObject.changeGold(1);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(1, 0, 0));
    }
}
