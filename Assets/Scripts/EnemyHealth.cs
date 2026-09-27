using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hp;

    int currentHp;

    void Awake()
    {
        currentHp = hp;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;

        if (currentHp < 0) {
            Destroy(gameObject);
        }
    }
}
