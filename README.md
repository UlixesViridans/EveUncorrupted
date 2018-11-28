//# WP-EVE-Project
//Windows Programming Final Project

//Website for figuring out various API calls to use
// https://esi.evetech.net/ui#/Market/get_markets_region_id_orders

//Website for figuring out the region IDs of various regions by name
// https://www.adam4eve.eu/info_locations.php


//psuedo code

main()
{
	int regionID = getLastState();
	
	//raw list from the server
	List rawOrders;
	
	//non unique sell orders
	List sellOrders;
	
	//non unique buy orders
	List buyOrders;
	
	//unique sell orders
	List uniqueSellOrders;
	
	//unique buy orders
	List uniqueBuyOrders;
	
	//starts the process when the search button is pressed
	actionlistener(button go)
	{
		//clear lists
		rawOrders.clear();
		sellOrders.clear();
		buyOrders.clear();
		uniqueSellOrders.clear();
		uniqueBuyOrders.clear();
		
		try
		{
			rawOrders = pullfromserver(readfromsearchbox());
			regionID = readfromsearchbox();
			
			 
			
		}
		catch
		{
			//malformed name
			//not connected
			//etc...
		}
		
		//splits into buy and sell orders
		splitRawOrders(rawOrders, sellOrders, buyOrders);
		
		parseBuyOrders(buy, uniqueBuy);
		
		parseSellOrders(sell, uniqueSell);
		
		
		display(uniqueSell, uniquebuy)
		
		
	}
	
	actionlistener(button exit)
	{
		SaveState(regionID);
	}
	
	//splits the raw data into buy and sell orders
	void splitRawOrders(List in1, List sell, List buy)
	{
		foreach(object order in in1)
		{
			if(object order.is_buy_order == true)
			{
				buy.add(order);
			}
			else
			{
				sell.add(order);
			}
		}
	}
	
	////////////////////////////////////////////////////////////
	//best way to do this for time efficiency would be to use
	//a hash lookup table by each item id. So each item
	//can be searched for in linear time
	//big O of 2n^2 currently, so awful
	
	//populates the uniqueBuy list with unique items
	//by typeId
	//then goes through the nonunique list and replaces
	//the buy orders so each has the highest buy orders
	//for the list
	void parseBuyOrders(List buy, List uniqueBuy)
	{
		foreach(object order in buy)
		{
			//checks if an order doesn't exist in the unique list
			if(objectExistance(uniqueBuy, order) != true )
			{
				uniqueBuy.add(order);
			}
			else
			{
				//go here if the object already exists in the unique table
				//check prices of both
				int orderIndex = findOrder(uniqueBuy, order.typeId);
				
				//if the order price is higher than the one in the unique
				//list then replace
				if(order.price >= uniqueBuy.Item[orderIndex].price)
				{
					//replace
					uniqueBuy.RemoveAt(orderIndex);
					uniqueBuy.add(order);
				}
			}
		}
	}
	
	//populates the uniqueSell list with unique items
	//by typeId
	//then goes through the nonunique list and replaces
	//the sell orders so each has the lowest sell orders
	//for the list
	void parseSellOrders(List sell, List uniqueSell)
	{
		foreach(object order in sell)
		{
			//checks if an order doesn't exist in the unique list
			if(objectExistance(uniqueSell, order) != true )
			{
				uniqueSell.add(order);
			}
			else
			{
				//go here if the object already exists in the unique table
				//check prices of both
				int orderIndex = findOrder(uniqueSell, order.typeId);
				
				//if the order's sell price is lower than the one in the uniquelist
				//then sell
				if(order.price <= uniqueSell.Item[orderIndex].price)
				{
					//replace
					uniqueSell.RemoveAt(orderIndex);
					uniqueSell.add(order);
				}
			}
		}
	}
	//////////////////////////////////////////////////////////////////
	
	//finds an order based on its' type ID and returns the index of it
	//only works in unique lists
	//returns -1 if nothing is found
	int findOrder(List a, int typeID)
	{
		foreach(object order in a)
		{
			if(order.typeId == typeID)
			{
				return a.IndexOf(order);
			}
		}
	
		return -1;
	}
	
	//checks if an object exists in a list, returns a bool based on
	//this
	bool objectExistance(List list, object order)
	{
		foreach(object ord in list)
		{
			if(ord.typeId == order.typeId)
			{
				return true;
			}
			
		}
		
		return false;
	}
	
}
