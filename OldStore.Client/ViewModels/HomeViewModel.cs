using OldStore.Client.Services;
using OldStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OldStore.Client.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {

        public bool IsLoading { get; set; }

        public ObservableCollection<BlockModel> Blocks { get; set; } = new ObservableCollection<BlockModel>();


        private readonly ApiService apiService;
        public HomeViewModel(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task LoadContentAsync()
        {
            try
            {
                IsLoading = true;
                Changed("IsLoading");
                var catalog = await this.apiService.GetHomeCatalog();
                foreach(var block in catalog.Blocks)
                {
                    Blocks.Add(block);
                }

                IsLoading = false;

                Changed("Blocks");
                Changed("IsLoading");

            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
