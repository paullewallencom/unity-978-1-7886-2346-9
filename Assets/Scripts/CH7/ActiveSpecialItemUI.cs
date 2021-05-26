using UnityEngine.EventSystems;

public class ActiveSpecialItemUI : EventTrigger
{

  public override void OnPointerClick(PointerEventData data)
  {
    //Debug.Log("OnPointerClick called.");

    InventoryItem iia = this.gameObject.GetComponent<ActiveInventoryItemUI>().item;

    switch(iia.CATEGORY)
    {
      case BaseItem.ItemCatrgory.HEALTH:
        {
          //this.health.Add(item);

          // add the item to the special items panel
          //GameMaster.instance.UI.ApplySpecialInventoryItem(iia);
          Destroy(this.gameObject);

          break;
        }
      case BaseItem.ItemCatrgory.POTION:
        {
          //this.potion.Add(item);
          break;
        }
    }

  }

  //// Use this for initialization
  //void Start () {

  //}

  //// Update is called once per frame
  //void Update () {

  //}
}
