using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviour : MonoBehaviour
{
    //classe abstrata para cuidar de mandar as informacoes para controlar os imigos mais facil
    public abstract void PerformDetection(Boat_Controller boat, AIDetector detector);

}
