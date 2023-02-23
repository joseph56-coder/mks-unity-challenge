using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //instanciando objeto
    public float speed = 3f;

    //faz seguir o alvo
    public void FollowTarget(Transform Target)
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
    }
}
