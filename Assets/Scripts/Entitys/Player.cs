using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : WorldEntity
{
    [SerializeField] float playerMoveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Weapon weapon;
    [SerializeField] SovetGlove alternativeWeapon;
    [SerializeField] HealthController healthController;

    private Rigidbody2D _rigidBody;
    [SerializeField] bool isGrounded;


    protected new void Start()
    {
        base.Start();
        this._rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void Update()
    {
        //Атака
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.alternativeWeapon.Attack();
        }
        //Передвижение по горизонатли (вперед и назад)
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.Move();
        }
        //Прыжки
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            this.Jump();
        }

    }

    /**
     * Передвижение
     */
    public void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        //this._rigidBody.velocity = (new Vector2(moveDirection * this.playerMoveSpeed, 0));
        this._rigidBody.AddForce(new Vector2(moveDirection * this.playerMoveSpeed, 0));
    }

    /**
     * Прыжок
     */
    public void Jump()
    {
        this._rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }


    public void LookRight()
    {
        transform.Rotate(1, 0, 0);
    }

    public void LookLeft()
    {
        transform.Rotate(-1, 0, 0);
    }

    public void LookFront()
    {

    }


    public Weapon GetWeapon()
    {
        return this.weapon;
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public SovetGlove GetAlternativWeapon()
    {
        return this.alternativeWeapon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Обработка сбора предметов
        if (collision.GetComponent<Item>())
        {
            switch (collision.GetComponent<Item>().GetType().Name)
            {
            
            }



        }  
    }

    public new void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthController.SetHealth(this.GetHealth() / this.maxHealth);
    }
}
