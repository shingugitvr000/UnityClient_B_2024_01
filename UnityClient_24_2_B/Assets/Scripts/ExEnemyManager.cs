using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExEnemyManager : MonoBehaviour
{
    public List<ExEnemy> enemies = new List<ExEnemy>();

    // Start is called before the first frame update
    void Start()
    {
        //데이지가 낮은 순서대로 적 캐릭터 정렬
        var sortedEnemies = enemies.OrderBy(enemy => enemy.damage);

        foreach (var enemy in sortedEnemies)
        {
            Debug.Log("Sorted Enemy : " + enemy.gameObject.name + " Damage : " + enemy.damage);
        }

        //특정 거리 이내의 적 캐릭터 선택
        float maxDistance = 10f;
        var closeEnemies = enemies.Where(enemy => Vector3.Distance(enemy.transform.position, transform.position) < maxDistance);

        foreach (var enemy in closeEnemies)
        {
            Debug.Log("Close Enemies : " + enemy.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
