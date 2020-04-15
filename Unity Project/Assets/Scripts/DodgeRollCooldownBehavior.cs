using System.Collections;
using UnityEngine;

public class DodgeRollCooldownBehavior : MonoBehaviour
{
    public BoolDataSO dataObj;
    public float cooldownTime = 1f;
    private WaitForSeconds cooldownWaitObj;

    private void Start()
    {
        cooldownWaitObj = new WaitForSeconds(cooldownTime);
    }

    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        dataObj.boolData = false;
        yield return cooldownWaitObj;
        dataObj.boolData = true;
    }
}