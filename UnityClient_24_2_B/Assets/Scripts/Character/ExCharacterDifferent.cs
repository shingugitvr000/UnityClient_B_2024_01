using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterDifferent : ExCharacter
{
    protected override void Move()
    {
        base.Move();
        transform.Translate(
            Vector3.up * speed  * Time.deltaTime);
    }
}
