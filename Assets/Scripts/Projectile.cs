using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;

    private float movementSpeed = 0.75f;

    [SerializeField]
    private string targetTag = "Enemy";

    private Vector2 direction = Vector2.right;

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void Damage(int damage)
    {
        if (target && target.GetComponent<Health>())
        {
            target.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
    }

    public void InvertGameObject()
    {
        var tempLocalScale = gameObject.transform.localScale;
        Vector3 invertedSide = new Vector3(tempLocalScale.x * -1, tempLocalScale.y, tempLocalScale.z);
        gameObject.transform.localScale = invertedSide;
    }

    private void Update()
    {
        if (direction != null)
            transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        bool collidedWithEnemyCharacter = otherGameObject.tag.Equals(targetTag) && 
            otherGameObject.GetComponent<Character>();
        if (collidedWithEnemyCharacter)
        {
            target = otherGameObject;
            GetComponent<Animator>().SetTrigger("hitted");
        }
    }
}
