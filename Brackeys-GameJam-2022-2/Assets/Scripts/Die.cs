using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float TimeTodie;
//a

    void Start()
    {
        Destroy(this.gameObject, TimeTodie);
    }

}
