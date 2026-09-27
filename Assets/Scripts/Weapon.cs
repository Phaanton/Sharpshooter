using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator shootAnimation;
    [SerializeField] GameObject hitVFXPrefab;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlash.Play();
        shootAnimation.Play(SHOOT_STRING, 0, 0f);

        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Vector3 hitTargetPoint = hit.point;
            Instantiate(hitVFXPrefab, hitTargetPoint, Quaternion.LookRotation(hit.normal));

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damage);
        }
    }
}
