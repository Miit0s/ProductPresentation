using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
