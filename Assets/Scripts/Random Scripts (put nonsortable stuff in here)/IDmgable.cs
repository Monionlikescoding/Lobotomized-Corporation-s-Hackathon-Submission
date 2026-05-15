using UnityEngine;

public interface IDmgable
{
    float Health {get; set;}
    float MaxHP {get; set;}
    float Sp {get; set;}
    float MaxSp {get; set;}
    float Soul {get; set;}
    float MaxSoul {get; set;}

    public void AdjustSp(float a);
    public void AdjustHp(float a);
    public void AdjustSoul(float a);
    public void Die();
}
