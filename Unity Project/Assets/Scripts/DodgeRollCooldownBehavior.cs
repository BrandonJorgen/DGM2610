using System.Collections;
using UnityEngine;

public class DodgeRollCooldownBehavior : MonoBehaviour
{
    public BoolDataSO dataObj;
    public float cooldownTime = 1f;

    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        dataObj.boolData = false;
        yield return new WaitForSeconds(cooldownTime);
        dataObj.boolData = true;
    }
}