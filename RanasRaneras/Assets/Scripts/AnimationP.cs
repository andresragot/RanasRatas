using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationP : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation Red;

    int counter = 3;
    public GameObject rana;
    void Start()
    {
        Red = gameObject.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 2 || counter == 1 || counter == 0)
        {
            Red.Play("LifeLo");
            Debug.Log("Le pega");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            counter--;
        }
    }
}
