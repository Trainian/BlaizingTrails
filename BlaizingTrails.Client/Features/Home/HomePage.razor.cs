using System.Net.Http.Json;

namespace BlaizingTrails.Client.Features.Home
{
    public partial class HomePage
    {
        private IEnumerable<Trail>? _trails;
        private Trail? _selectedTrail;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _trails = await Http.GetFromJsonAsync<IEnumerable<Trail>>("trails/trail-data.json");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"There was a problem loading trail data: {ex.Message}");
            }
        }

        private void HandleTrailSelected(Trail trail) => _selectedTrail = trail;
    }
}
