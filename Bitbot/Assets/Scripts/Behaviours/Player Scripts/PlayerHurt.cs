using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public FloatReference startingHP;
    public FloatVariable currentHP;
    private EventManager em;
    private AudioManager am;
    private AnimationScript anim;

    private void Awake()
    {
        anim = FindObjectOfType<AnimationScript>();
        am = FindObjectOfType<AudioManager>();
        em = FindObjectOfType<EventManager>();
        currentHP.SetValue(startingHP);
    }

    private void OnEnable()
    {
        em.OnPlayerHurtEvent += DecreaseHealth;
    }
    private void OnDisable()
    {
        em.OnPlayerHurtEvent -= DecreaseHealth;
    }

    private void DecreaseHealth(float amount)
    {
        currentHP.ApplyChange(-amount);
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        am.PlaySound("Player Hit");
        anim.TriggerAnim("Hurt");
        
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.35f);
    }
}
