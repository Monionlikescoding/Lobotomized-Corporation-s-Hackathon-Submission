using UnityEngine;

public interface IAbno {

    GameObject Player{ get; set; } 
    float[] PlayerStats{ get; set; } 
    int DmgType{ get; set; } 
    int DmgAmnt{ get; set; } 
    bool CanEscape{ get; set; } 
    bool HasAngerMeter{ get; set; } 
    int MaxAngerCount{ get; set; } 
    int AngerCount{ get; set; } 
    int ThreatLevel{ get; set; } 
    int AmountOfWorks { get; set; }
    float ChanceToGetGift{ get; set; } 
    float ChanceToGetEnkH{ get; set; } 
    float ChanceToGetEnkM{ get; set; } 
    float ChanceToGetEnkS{ get; set; } 
    float WorkTime{ get; set; } 
    int Id { get; set; }



    public void onBadWorkResult();

    public void onNormalWorkResult();

    public void onGoodWorkResult();

    public void onEmployeeDeath();

    public void getEgoGift();
}
