using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float viewRadious = 11;
    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityPlayer;

    [field: SerializeField]
    public bool TargetVisiible {get;private set;}

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisiible = false;
        }
    }

    private void Start() 
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update() 
    {
        if (Target != null)
        {
            TargetVisiible = CheckTargetVisible();
            Debug.Log("vejo");
        }
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadious,
        visibilityPlayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void DetectionTarget()
    {
        if (Target == null)
        {
            CheckIfPlayerInRange();
        }
        else if(Target != null)
        {
            DetectIfOutOfRange();
        }
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadious, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position,
        Target.position) > viewRadious)
        {
            Target = null;
        }
        
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectionTarget();
        StartCoroutine(DetectionCoroutine());
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, viewRadious);
    }
}
