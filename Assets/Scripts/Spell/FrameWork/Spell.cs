using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public SpellTypes.SpellType SpellType { get; set; }
    public Transform castPoint { get; set; }

    [SerializeField]
    public int ManaCost { get; set; }
    [SerializeField]
    public float Damage { get; set; }
    public virtual void Cast() {
        Debug.Log("Base cast");

    }

    void Start()
    {
        castPoint = transform.Find("CastPoint");
    }
}
