using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Raycast Spell", menuName = "Spells/Raycast")]
public class Spell_Raycast : Spell
{
    public float DamageOverride;
    private Transform castPoint { get; set; }

    private void Awake()
    {
        SpellType = SpellTypes.SpellType.Raycast;
    }


    Spell_Raycast(Transform castPoint)
    {
        this.castPoint = castPoint;
    }

    Spell_Raycast(Transform castpoint, float manaPool)
    {
        this.castPoint = castPoint;
    }

    public void Cast()
    {
        if (castPoint != null)
        {
            Vector2 origin = new Vector2(castPoint.position.x, castPoint.position.y);
            

            RaycastHit2D hit = Physics2D.Raycast(origin, castPoint.up);
            Debug.DrawLine(origin, hit.point);

            if (hit)
            {
                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.TakeDamage(DamageOverride);
                }
            }
        }
    }
}
