using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviour : MonoBehaviour
{
    public abstract void PerformDetection(Boat_Controller boat, AIDetector detector);
    
}
