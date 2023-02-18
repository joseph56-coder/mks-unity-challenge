using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviours : AIBehaviour
{

    public float fieldOfVisionForShooting = 60;
    public override void PerformDetection(Boat_Controller boat, AIDetector detector)
    {
        if (TargetInFOV(boat, detector))
        {
            boat.HandleMoveBody(Vector2.zero);
            boat.FrontShooter();
        }
        boat.HandleBoatTurn(detector.Target);
    }

    private bool TargetInFOV(Boat_Controller boat, AIDetector detector)
    {
        var direction = detector.Target.position - boat.Rotate.transform.position;
        if (Vector2.Angle(boat.Rotate.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
