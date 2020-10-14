using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleReload : MonoBehaviour
{
    private EventManager em;
    void Awake()
    {
        em = FindObjectOfType<EventManager>();
    }
    private void OnEnable()
    {
        em.OnGunReloadEvent += ExecuteReload;
        em.OnGunEmptyEvent += EmptyClick;
    }
    private void OnDisable()
    {
        em.OnGunReloadEvent -= ExecuteReload;
        em.OnGunEmptyEvent -= EmptyClick;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            em.OnGunReloadEventEventMethod();
        }
    }

    private void ExecuteReload()
    {
        IReloadable reloadable = GetComponent<IReloadable>();
        reloadable?.Reload();
    }

    private void EmptyClick()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }
}
