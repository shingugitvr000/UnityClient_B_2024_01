using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private int index;
    private string name;
    private ItemType type;
    private Sprite image;

    //프로퍼티 
    public int Index
    {
        get { return index; }
       
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }

    public Sprite Image
    {
        get { return image; }
        set { image = value; }
    }


    public Item(int index, string name, ItemType type)
    {
        this.index = index;
        this.name = name;
        this.type = type;
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Potion,
    QuestItem
    //다양한 아이템 등록
}

public class Inventory
{
    private Item[] items = new Item[16];

    //아이템 인덱서(indexer)
    public Item this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }
    public int InventoryCount
    {
        get {return items.Length;}
    }
    //현재 인벤토리에 있는 아이템 수
    public int ItemCount
    {
        get
        {
            int count = 0;
            foreach(Item item in items) 
            {
                if(item != null)
                    count++;
            }
            return count;
        }        
    }
    //아이템 추가
    public bool AddItem(Item item)
    {
        for(int i = 0; i < items.Length; i++) 
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false;   //인벤토리에 빈칸이 없는 겨우
    }
    //아이템 제거
    public void RemoveItem(Item item) 
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                break;
            }
        }
    }

}


public class ExGameSystem : MonoBehaviour
{
    private Inventory inventory = new Inventory();

    Item sword = new Item(0, "Sword", ItemType.Weapon);
    Item shield = new Item(0, "Shield", ItemType.Armor);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.AddItem(sword);

            Debug.Log("inventory : " + GetInventoryAsString());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.AddItem(shield);
            Debug.Log("inventory : " + GetInventoryAsString());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.RemoveItem(sword);
            Debug.Log("inventory : " + GetInventoryAsString());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.RemoveItem(shield);
            Debug.Log("inventory : " + GetInventoryAsString());
        }
    }

    private string GetInventoryAsString()
    {
        string result = "";
        for(int i = 0; i < inventory.InventoryCount; i++) 
        {
            if (inventory[i] != null)
            {
                result += inventory[i].Name + ",";
            }
        }

        return result.TrimEnd(',');
    }
}
