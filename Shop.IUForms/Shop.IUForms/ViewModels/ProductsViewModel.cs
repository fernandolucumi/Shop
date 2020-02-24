

namespace Shop.IUForms.ViewModels
{
    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Product> products;
        private bool isRefreshing;
        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetValue(ref products, value);
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }

        public ProductsViewModel()
        {
            apiService = new ApiService();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;
            Response response = await apiService.GetListAsync<Product>(
                "https://shopnice.azurewebsites.net",
                "/api",
                "/Products");

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");

                return;
            }

            List<Product> myProducts = (List<Product>)response.Result;
            Products = new ObservableCollection<Product>(myProducts);
        }
    }


}
