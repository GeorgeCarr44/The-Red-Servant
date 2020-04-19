using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Spell_Raycast
{

    //why do i need a constructor
    //get set types arent visable in the editor, how do i fix this??

    public override int ManaCost { get; set; }
    public override float Damage { get; set; }

public override void ApplyDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}
