using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryIfDisable : MonoBehaviour
{
    public bool SelfDestructionEnable { get; set; } = false;

    void OnDisable()
    {
        if (SelfDestructionEnable)
        {
            Destroy(gameObject);
        }
    }
}
