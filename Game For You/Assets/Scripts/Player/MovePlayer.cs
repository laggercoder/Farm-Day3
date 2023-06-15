using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] public float speed = 6;
    [SerializeField] public Animator animator;
    [SerializeField] public float horizontal;
    [SerializeField] public float vertical;
    private void FixedUpdate()
    {
        
        
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        AnimatorMove(horizontal);
        Vector3 direction = new Vector3(horizontal, vertical);
        transform.parent.position += direction * speed * Time.fixedDeltaTime;
    } 
    private void AnimatorMove( float horizontal)
    {
        if (animator == null) return;
 
        if(horizontal != 0)
        {
            animator.SetBool("isWalk", true);
            animator.SetFloat("moveLeft", horizontal);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }
}
