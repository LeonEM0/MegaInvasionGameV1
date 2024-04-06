using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator1k : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform aimPoint;

    // Update is called once per frame
    private void OnAnimatorIK(int layerIndex)
    {
        if (!animator) return;
        animator.SetLookAtPosition(aimPoint.position);
        animator.SetLookAtWeight(1,1);



    }
}
