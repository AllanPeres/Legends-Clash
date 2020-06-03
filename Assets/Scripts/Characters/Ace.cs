using UnityEngine;
using System.Collections;

public class Ace : Character
{

    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private GameObject gun;

    private bool shooted = false;

    protected override void UpdateAction()
    {
        if (!shooted)
        {
            VerifyExistingEnemies();
        }
    }

    private void VerifyExistingEnemies()
    {
        Character[] characters = FindObjectsOfType<Character>();
        foreach(Character character in characters)
        {
            if (character.tag.Equals(targetTag))
            {
                shooted = true;
                ShootTrigger();
                return;
            }
        }
    }

    private void ShootTrigger()
    {
        animator.SetTrigger("shoot");
    }

    public void Shoot()
    {
        var shootedProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        shootedProjectile.SetDirection(direction);
        shootedProjectile.SetTargetTag(targetTag);
        if (direction.Equals(Vector2.left))
        {
            shootedProjectile.InvertGameObject();
        }
    }
}
