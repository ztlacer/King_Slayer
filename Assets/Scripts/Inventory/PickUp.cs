using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Color color = new Color(0.8f,0.8f,0,1.0f);
    public float scroll = 0.05f;  // scrolling velocity
    public float duration = 5.5f; // time to die
    public float alpha;
    [SerializeField] public TextMeshPro text;
 
    void Start()
    {
        text.material.color = color; // set text color
        alpha = 1;
    }

    void Update()
    {
        if (alpha > 0)
        {
            transform.position += new Vector3(0, scroll * Time.deltaTime, 0);
            alpha -= Time.deltaTime / duration;
            text.material.color = new Color(text.material.color.r, text.material.color.g, text.material.color.b, alpha);
        }
        else
        {
            Destroy(gameObject); // text vanished - destroy itself
        }
    }
}
