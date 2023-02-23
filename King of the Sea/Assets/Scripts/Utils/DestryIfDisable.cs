using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryIfDisable : MonoBehaviour
{//instanciando objeto
    public bool SelfDestructionEnable { get; set; } = false;

    //destroi objeto se desativado
    void OnDisable()
    {
        if (SelfDestructionEnable)
        {
            Destroy(gameObject);
        }
    }
}
