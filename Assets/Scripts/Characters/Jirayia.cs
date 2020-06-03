using UnityEngine;
using System.Collections;

public class Jirayia : Character
{
    private int attackCounter = 0;

    protected override void Attack()
    {
        if (attackCounter >= 3)
        {
            SuperAttackTrigger();
        } else {
            attackCounter++;
            base.Attack();
        }
    }

    private void SuperAttackTrigger()
    {
        animator.SetTrigger("rasengan");
        attackCounter = 0;
    }

}
