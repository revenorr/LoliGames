using UnityEngine;

public class causticDamage : MonoBehaviour
{
    private int damage;
    private bool inDamage=false;
    public float TickSpeed=1f;
    [SerializeField]private float SphereRadius;
    private LvlUp lvlUp;
    private void Awake()
    {
        SphereRadius = gameObject.GetComponent<SphereCollider>().radius;
        lvlUp = FindObjectOfType<LvlUp>();
        damage = lvlUp.CurrentCausticDamage;
    }


    private void CausticDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, SphereRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<Enemy>() )
            {
                collider.GetComponent<Enemy>().health -= damage;
            }
        }
    }
    /*private void OnTriggerStay(Collider collider)
    {
        CausticDamage();
    }*/
    private void OnTriggerStay(Collider collider)
    {
        GameObject col = collider.gameObject;
        Enemy EnnemyTakeDamage = col.GetComponent<Enemy>();
        if (EnnemyTakeDamage != null && inDamage == false)
        {
            inDamage = true;
            CausticDamage();
            Invoke(nameof(EnnemyTakeDamageTime), TickSpeed);

            
        }

    }
    private void EnnemyTakeDamageTime()
    {
        inDamage = false;      
    }
}
