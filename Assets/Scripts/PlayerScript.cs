using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -7.5f)
        {
            transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 7f)
        {
            transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }

        if (Input.GetKey(KeyCode.J))
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        EnemyScript enemy = collider.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
                damagePlayer = true;
            }
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
            }
        }
    }

    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
