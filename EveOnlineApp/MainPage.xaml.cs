using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EveOnlineApp
{
    public sealed partial class MainPage : Page
    {
        APIHelper APIHelper = new APIHelper();
        List<EveObjModel> importedList = new List<EveObjModel>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            string selectedRegion = regionBox.Text;
            if (selectedRegion.TrimEnd(' ').Length >= 1){

                try
                {
                    importedList = await APIHelper.GetData(selectedRegion);
                    if (importedList.Count <= 0)
                        DisplayErrorDialog("Could not load data from server", "Please refresh the application and try again.");
                    else
                        splitIntoBuySellLists(importedList);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                DisplayErrorDialog("No region detected", "You have to type in a region first!");
        }
        public async void DisplayErrorDialog(string title, string content)
        {
            ContentDialog ErrorDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await ErrorDialog.ShowAsync();
        }
        public void splitIntoBuySellLists (List<EveObjModel> importedList)
        {
            List<EveObjModel> sellList = new List<EveObjModel>();
            List<EveObjModel> buyList = new List<EveObjModel>();

            foreach (EveObjModel obj in importedList)
            {
                if (obj.Is_buy_order)
                    buyList.Add(obj);
                else
                    sellList.Add(obj);
            }
            CreateUniqueBuyList(buyList);
        }

        public void CreateUniqueBuyList(List<EveObjModel> buyList)
        {
            List<EveObjModel> uniqueBuyList = new List<EveObjModel>();
            List<long> typeIDSortHolder = new List<long>();

            foreach (EveObjModel obj in buyList)//.OrderBy(EveObjModel => EveObjModel.type_id))
            {   
                // int index sees how many items with the same type_id and with a lower price exists
                int index = buyList.FindIndex(item => (item.Type_id == obj.Type_id) && (item.Price < obj.Price));
                // if there is more than 0, that means that there are items we need to cut. 
                // We remove all where type_id is the same and the price is lower than the current objects. 
                if (index > 0)
                {
                    buyList.RemoveAll(x => x.Type_id == obj.Type_id && x.Price < obj.Price);
                }

                // int indexSecondRound checks if other objects with the same type_id exists. If they do, that
                // means that the current object is not the one with the highest price. There it is removed from the buyList. 
                int indexSecondRound = buyList.FindIndex(item => item.Type_id == obj.Type_id);
                // removes the current obj.
                if (indexSecondRound > 0)
                    buyList.Remove(obj);

                continue;
            }

            uniqueBuyList = buyList;

        }
    }
}
