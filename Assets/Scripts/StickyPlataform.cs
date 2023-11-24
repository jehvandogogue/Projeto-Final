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
            colision.gameObject.transform.localScale = new Vector3(0.2f, 10f, 0.2f);
        }
    }

    private void OnCollisionExit(Collision colision)
    {
        if (colision.gameObject.tag =="Player")
        {
            colision.gameObject.transform.SetParent(null);
            colision.gameObject.transform.localScale = Vector3.one;
        }
    }
}
