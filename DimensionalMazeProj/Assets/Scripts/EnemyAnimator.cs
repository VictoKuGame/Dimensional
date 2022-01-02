using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAnimator : MonoBehaviour
{
    Animator animator;
    int state;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        state = Animator.StringToHash("State");
    }
    public void UpdateAnimatorValues(float status)
    {
        animator.SetFloat(state, status, 0.1f, Time.deltaTime);
    }
}