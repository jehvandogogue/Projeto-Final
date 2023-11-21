using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlataform : MonoBehaviour
{
    private void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.tag =="Player")
        {
            colision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision colision)
    {
        if (colision.gameObject.tag =="Player")
        {
            colision.gameObject.transform.SetParent(null);
        }
    }
}
