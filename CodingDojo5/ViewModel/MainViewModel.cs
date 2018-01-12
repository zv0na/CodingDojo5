using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.CommandWpf;

namespace CodingDojo5.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ItemVm> Items { get; set; }
        public ObservableCollection<ItemVm> Einkaufswagen { get; set; }

        private RelayCommand<ItemVm> buyBtnClickedCmd;

        public RelayCommand<ItemVm> BuyBtnClickedCmd
        {
            get { return buyBtnClickedCmd; }
            set { buyBtnClickedCmd = value; }
        }


        private ItemVm auswahl;

        public ItemVm Auswahl
        {
            get { return auswahl; }
            set { auswahl = value; RaisePropertyChanged(); }
        }

        

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemVm>();
            Einkaufswagen = new ObservableCollection<ItemVm>();

            BuyBtnClickedCmd = new RelayCommand<ItemVm>(Hinzufuegen);

            GenerateDemoDate();
        }
               
        private void Hinzufuegen(ItemVm obj)
        {
            Einkaufswagen.Add(obj);
        }

        private void GenerateDemoDate()
        {
            Items.Add(new ItemVm("MY Lego", "", new BitmapImage(new Uri("/Images/lego1.jpg", UriKind.Relative))));
            Items.Add(new ItemVm("MY Playmobil", "", new BitmapImage(new Uri("/Images/playmobil1.jpg", UriKind.Relative))));

            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", "5+", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative))));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", "10+", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
               new ItemVm("Lego 2", "5+", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
                new ItemVm("Lego 3", "10+", new BitmapImage(new Uri("Images/lego3.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
               new ItemVm("Lego 4", "5+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));
        }
    }
}