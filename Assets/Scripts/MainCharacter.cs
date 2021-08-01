using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Rigidbody2D body;
    private float scaleX;
    private float scaleY;
    
    private float moveSpeed = 5.0f;
    private float moveDirection;

    private Animator animator;

    private float attackCooldown = 0.5f;
    private float attackTimer = 0f;

    [SerializeField] AttackTrigger attackTrigger;
    private List<Rigidbody2D> enemies;

    [SerializeField] HitArea hitArea;
    private float counterDuration = 1.0f;
    private float counterTimer = 0.0f;

    private Vector2 attackForce = new Vector2(1.0f, 1.0f);

    private float dodgeCooldown = 0.0f;
    private float dodgeTimer = 0f;

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        CheckMoveDirection();
        Attack();
        Dodge();
        CounterAttack();
    }
    
    private void FixedUpdate() 
    {
        // body.velocity = new Vector2(moveDirection * moveSpeed, body.velocity.y);
        body.AddForce(new Vector2(moveDirection * 20.0f, 0.0f));
        if(Mathf.Abs(body.velocity.x) > moveSpeed)
        {
            body.velocity = new Vector2(moveDirection * moveSpeed, body.velocity.y);
        }
    }

    private void CheckMoveDirection()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");

        if(moveDirection > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if(moveDirection < 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }
    }

    private void Attack()
    {
        if(attackTimer <= 0)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if(counterTimer > 0)
                {
                    animator.Play("CounterAttack");
                    attackTimer = attackCooldown;
                    counterTimer = 0.0f;
                    attackForce = new Vector2(1.5f, 1.5f);
                }
                else
                {
                    animator.Play("SwordAttack");
                    attackTimer = attackCooldown;
                    attackForce = new Vector2(1.0f, 1.0f);
                }
                
            }
            
        }
        else
        {
            attackTimer -= Time.deltaTime;
            enemies = attackTrigger.GetEnemies();
            if(enemies.Count > 0)
            {
                foreach(Rigidbody2D enemy in enemies)
                {
                    enemy.AddForce(new Vector2(attackForce.x * transform.localScale.x * -enemy.gameObject.transform.localScale.x, attackForce.y));
                }
            }
        }
    }

    private void Dodge()
    {
        if(dodgeTimer <= 0)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                animator.Play("Dodge");
                dodgeTimer = dodgeCooldown;
            }
            
        }
        else
        {
            dodgeTimer -= Time.deltaTime;
        }
    }

    private void CounterAttack()
    {
        if(hitArea.GetIsCountering())
        {
            counterTimer = counterDuration;
        }

        if(counterTimer > 0)
        {
            counterTimer -= Time.deltaTime;
        }
    }
}
