using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public abstract SpellTypes.SpellType SpellType { get; set; }
    
    public abstract int ManaCost { get; set; }
    public abstract float Damage { get; set; }
    public abstract void Cast();




}
