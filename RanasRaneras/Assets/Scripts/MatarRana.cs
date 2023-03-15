using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarRana : MonoBehaviour
{
    [SerializeField]
    Transform ranaCheck;
    [SerializeField]
    LayerMask ranaLayer;

    BoxCollider2D box;

    RaycastHit2D raycast;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectarRana())
        {
            Debug.Log(raycast.collider.tag);
            if(raycast.collider!=null && raycast.collider.tag == "Rana")
            {
                Corazones cora = raycast.collider.GetComponent<Corazones>();
                cora.Vida--;
            }
        }
    }

    private bool DetectarRana()
    {
        raycast = Physics2D.BoxCast(ranaCheck.position, box.bounds.size, 0, Vector2.down, 1, ranaLayer);
        return raycast;
    }
}
