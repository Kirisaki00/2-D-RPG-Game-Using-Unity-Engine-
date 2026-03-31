using System.Collections;
using UnityEngine;

public class Entity_VFX : MonoBehaviour
{
    private SpriteRenderer sr;
    [Header("On Damage VFX")]
    [SerializeField] private Material onDamageMaterial;
    [SerializeField] private float onDamageDuration = .2f;
    private Material originalMaterial;
    private Coroutine onDamageVFXcoroutine;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;
    }
    public void PlayOnDamageVFX()
    {
        if (onDamageVFXcoroutine != null)
            StopCoroutine(onDamageVFXcoroutine);
        onDamageVFXcoroutine = StartCoroutine(OnDamageVFX_Co());
    }
    private IEnumerator OnDamageVFX_Co()
    {
        sr.material = onDamageMaterial;
        yield return new WaitForSeconds(onDamageDuration);
        sr.material = originalMaterial;
    }

}
