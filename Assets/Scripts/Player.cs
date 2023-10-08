using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using CardSystem;

public class Player : MonoBehaviour
{
    public float speed;
    //public Animation attack;
    private Animator animator;

    private bool isMoving;
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    //人物技能激活状态
    public enum Player_State
    {
        Walk,
        Sword,
        Bow,
        Bomb,   //催城
        Dead,
    };

    public Player_State player_state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_state = Player_State.Walk;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        Move();
        Stable();
    }

    private void MoveControl()
    {
        if (isMoving)
            return;
        if (player_state = Player_State.Bow)
        {//射箭时不会移动
            BowAttack();
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player_state = Player_State.Walk;
            // 需要相应的UI动画，激活功能，下同
            // TODO
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player_state = Player_State.Sword;
            // TODO
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player_state = Player_State.Bow;
            // TODO
        }
    }

    private void Move()
    {
        if (isMoving)
            animator.SetBool("isMoving", true);
        if (up == true)
        {
            this.transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        }
        else if (down == true)
        {
            this.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }
        else if (left == true)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
        }
        else if (right == true)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            up = false;
            down = false;
            left = false;
            right = false;
            isMoving = false;
            player_state = Player_State.Walk;
        }
        else if (collision.collider.tag == "Enemy")
        {
            if (player_state == Player_State.Sword) SwordAttack(collision);
            else
            {
                isMoving = false;
                Die();
            }
        }
    }

    private void Stable()
    {
        if (isMoving == false)
        {
            this.transform.position = new Vector2(math.round(this.transform.position.x), math.round(this.transform.position.y));
            this.transform.eulerAngles = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
    }

    public void SwordAttack(Collision2D collision)
    {
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        enemy.Die();
    }
    public void BowAttack()
    {
        // TODO
    }
    public void Die()
    {
        animator.SetBool("Dead", true); // 播放死亡动画
        player_state = Player_State.Dead;
    }

}