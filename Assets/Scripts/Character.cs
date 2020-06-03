using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] protected float speedMovement = 1f;
    [SerializeField] protected string targetTag = "Enemy";
    [SerializeField] public int cost = 100;

    protected GameObject target;
    protected Animator animator;
    protected const string IS_ATTACKING = "isAttacking";
    protected Vector2 direction;

    protected bool isAttacking = false;

    public void SetMovementSpeed(float speed)
    {
        speedMovement = speed;
    }

    public void DamageTarget(int damage)
    {
        if (target)
        {
            Health targetHealth = target.GetComponent<Health>();
            if (targetHealth) targetHealth.TakeDamage(damage);
        }
    }

    public void VerifyState()
    {
        isAttacking = (target && target.tag.Equals(targetTag));
        if (isAttacking)
            Attack();
        else
            Walk();
    }

    protected void Start()
    {
        animator =  GetComponent<Animator>();
    }

    private void Awake()
    {
        ChooseDirection();
    }

    private void ChooseDirection()
    {
        if (gameObject.tag.Equals("Enemy")) 
            direction = Vector2.left;
        else
            direction = Vector2.right;
    }

    void Update()
    {
        UpdateAction();
        if (!target) transform.Translate(direction * speedMovement * Time.deltaTime);
    }

    protected virtual void UpdateAction() {}

    protected void Walk()
    {
        animator.SetBool(IS_ATTACKING, false);
    }

    protected void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (ShouldChangeTarget(otherCollider))
        {
            SetColliderAndAttack(otherCollider);
        }
    }

    private void SetColliderAndAttack(Collider2D otherCollider)
    {
        target = otherCollider.gameObject;
        Attack();
    }

    private bool ShouldChangeTarget(Collider2D otherCollider)
    {
        bool targetIsNotACharacter = target && !target.GetComponent<Character>();
        bool isNotAttacking = !isAttacking;
        bool colliderHasTargetTag = otherCollider.gameObject.tag.Equals(targetTag);
        return targetIsNotACharacter || (isNotAttacking && colliderHasTargetTag);
    }

    protected virtual void Attack()
    {
        animator.SetBool(IS_ATTACKING, true);
    }
}
