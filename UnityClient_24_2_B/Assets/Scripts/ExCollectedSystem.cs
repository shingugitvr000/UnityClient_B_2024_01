using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExItem
{
    public bool IsCollected;                //획득 여부
}

public class ExCollectedSystem : MonoBehaviour
{
    public List<ExItem> collectedItem = new List<ExItem>();     //컬랙팅 할 리스트 
    
    // Start is called before the first frame update
    void Start()
    {
        collectedItem.Add(new ExItem());
        collectedItem.Add(new ExItem());
        collectedItem[0].IsCollected = true;
        collectedItem[1].IsCollected = true;
        CheckAllItemsCollected();
    }

    void CheckAllItemsCollected()
    {
        if(collectedItem.All(item => item.IsCollected)) //모든 아이템이 수집 되었는지 검사
        {
            Debug.Log("All items collected");
        }
        else
        {
            Debug.Log("Not all items collectd! ");
        }
    }

}
