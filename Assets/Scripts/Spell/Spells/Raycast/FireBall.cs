using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class FireBall : Spell_Raycast
public class FireBall : Spell_Raycast
{
    //get set types arent visable in the editor, how do i fix this??

    public override void ApplyDamage(Target t)
    {
        t.TakeDamage(10);
    }

    public override void Cast()
    {
        Debug.Log("cast");
        CastRay();
    }
}
