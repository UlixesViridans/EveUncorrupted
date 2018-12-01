using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    class ItemNameDatabase
    {
       public Dictionary<int, String> ItemNameDictionary;

       public ItemNameDatabase()
       {
            ItemNameDictionary = new Dictionary<int, string>();
       }

        //returns the english name for an item 
       public String GetItemName(int Item_ID)
        {
            return "";
        }

        //adds an item to the dictionary
        //use check existance to prevent 
        //exceptions from being thrown
        public void AddItem(EveObjModel item)
        {

        }


        //checks if the item exists in the Dictionary Database
        public bool CheckExistence(int Item_ID)
        {
            return false;
        }



    }
}
