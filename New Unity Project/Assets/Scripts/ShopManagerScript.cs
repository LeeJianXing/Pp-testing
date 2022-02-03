using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[6, 6];

    private int plusCilcked = 1;
    private int minusCilcked = -1;
    private int defaultQuantity = 1;
    private int defaultPrice = 0;


    public float coins;

    public Text CoinsTxt;
    public Text Quantity;
    public Text Price;
    public Text Confirmation;



    public GameObject BuyMenu;
    private int selectedItemID;
 

   


    void Start()
    {


        CoinsTxt.text = "Coins: " + coins.ToString();

        //ID 
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;


        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;

    }




    /* public void Buy()
      {
         GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

         if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
         {
             coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

             shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;

             CoinsTXT.text = "Coins:" + coins.ToString();

              ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();


         }

     }  */

    public void PopUp()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
       
        selectedItemID = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

        defaultQuantity = 1;
        defaultPrice = selectedItemID;
        Quantity.text = defaultQuantity.ToString();
        Price.text = defaultPrice.ToString();

        BuyMenu.SetActive(true);


    }

    public void NoClosePopUp()
    {
        BuyMenu.SetActive(false);
        defaultPrice = selectedItemID;
        defaultQuantity = 1;

        Quantity.text = defaultQuantity.ToString();
        Price.text = defaultPrice.ToString();

    }

    public void YesClosePopUp()
    {
        if (coins >= defaultPrice)
        {
            coins -= defaultPrice;

            CoinsTxt.text = "Coins: " + coins.ToString();

            BuyMenu.SetActive(false);
            defaultPrice = selectedItemID;
            defaultQuantity = 1;
            Quantity.text = defaultQuantity.ToString();
            Price.text = defaultPrice.ToString();

        }

    }

    public void PlusQuantity()
    {

        if (defaultQuantity < 50)
        {
            defaultQuantity += plusCilcked;
            defaultPrice = defaultQuantity * selectedItemID;

            Quantity.text = defaultQuantity.ToString();
            Price.text = defaultPrice.ToString();
        }



    }

    public void MinusQuantity()
    {
        if (defaultQuantity > 1)
        {
            defaultQuantity += minusCilcked;
            defaultPrice = defaultQuantity * selectedItemID;

            Quantity.text = defaultQuantity.ToString();
            Price.text = defaultPrice.ToString();
        }


    }

    public void ConfirmationBuy()
    {


        Confirmation.text = "Do you want to buy " + EventSystem.current.currentSelectedGameObject.name + "?";


    }

    




  




}