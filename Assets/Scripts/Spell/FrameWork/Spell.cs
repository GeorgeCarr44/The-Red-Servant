using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    public SpellTypes.SpellType SpellType { get; set; }
    
    public int ManaCost { get; set; }
    /// <summary>
    /// Default Damage
    /// </summary>
    public float Damage { get; set; }

    public void Cast()
    { 

    }
}
