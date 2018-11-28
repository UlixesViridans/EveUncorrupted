using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class is to take in the raw array lists from the website
/// and create hash tables of the buy and sell orders for faster 
/// performance
/// 
/// It also handles the methods currently places into the main file for neater
/// code and easier maintainance
/// 
/// 
/// Update, going to attempt using Dictionaries instead
/// </summary>
namespace EveOnlineApp
{
    class OrderHashTable
    {
        //raw hashtables

        private List<EveObjModel> RawBuyOrder;
        private List<EveObjModel> RawSellOrder;

        //uniquehashtables
        private Dictionary<int, EveObjModel> UniqueBuy;
        private Dictionary<int, EveObjModel> Uniquesell;

        //standard constructor for the order hashtable
        public OrderHashTable()
        {
            RawSellOrder    = new List<EveObjModel>();
            RawBuyOrder     = new List<EveObjModel>();
            UniqueBuy       = new Dictionary<int, EveObjModel>();
            Uniquesell      = new Dictionary<int, EveObjModel>();
        }


        public void Add_List_To_HashTable(List<EveObjModel> orderList)
        {

        }

        public List<EveObjModel> OutputBuyOrderList()
        {
            List<EveObjModel> uniqueList =  new List<EveObjModel>();
            //code goes here

            return uniqueList;

        }

        public List<EveObjModel> OutputSellOrderList()
        {
            List<EveObjModel> uniqueList = new List<EveObjModel>();
            //code goes here

            return uniqueList;

        }

    }
}
