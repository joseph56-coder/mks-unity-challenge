using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    public GameObject objectInstantiate;

    public void InstantiateObject()
    {
        Instantiate(objectInstantiate);
    }
}
