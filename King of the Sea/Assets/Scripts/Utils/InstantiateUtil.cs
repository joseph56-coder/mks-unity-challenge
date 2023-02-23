using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    //instanciando objeto
    public GameObject objectInstantiate;

    //instancia objetos na cena
    public void InstantiateObject()
    {
        Instantiate(objectInstantiate);
    }
}
