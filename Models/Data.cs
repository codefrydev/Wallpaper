using System.Text.Json;

namespace Wallpaper.Models
{
    public class Data
    {
        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();

        private List<Drawing> _data = [];
        private bool _isDataFetched;
        public List<Drawing> VideosData
        {
            get => _data;
            private set
            {
                _data = value;
                NotifyDataChanged();
            }
        }

        public bool isDataFetced = false; 

        string wallpaperPath = "https://raw.githubusercontent.com/codefrydev/Data/main/Wallpapers/wallpaper.json";   

        public async Task InitializeAsync()
        {
            if (_isDataFetched) return;
            VideosData = await FetchDataAsync();
            _isDataFetched = true;
        }

        private async Task<List<Drawing>> FetchDataAsync()
        {
            VideosData = [];
            if (isDataFetced) return VideosData;
            using (var client = new HttpClient())
            {
                var res =await client.GetAsync(wallpaperPath);

                var kk = await res.Content.ReadAsStringAsync();
                VideosData = JsonSerializer.Deserialize<List<Drawing>>(kk);

            } 
            isDataFetced = true;
            return VideosData;
        }
         
    }
}
