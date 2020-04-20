using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Raycast Spell", menuName = "Spells/Raycast")]
public abstract class Spell_Raycast : Spell
{
    private void Awake()
    {
        SpellType = SpellTypes.SpellType.Raycast;
    }

    public RaycastHit2D? CastRay()
    {
        if (castPoint != null)
        {
            Debug.Log("castpoint");
            Vector2 origin = new Vector2(castPoint.position.x, castPoint.position.y);

            RaycastHit2D hit = Physics2D.Raycast(origin, castPoint.up);
            Debug.DrawLine(origin, hit.point);

            if (hit)
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {

                    ApplyDamage(target);
                }
            }
        }

        Debug.Log("no castpoint");
        return null;
    }

    public abstract void ApplyDamage(Target t);
}
