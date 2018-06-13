using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchTerm;

        public string SearchTerm {
            get { return _searchTerm; }
            set
            {
                if (SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<string> Resultados { get; }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);

            Resultados = new ObservableCollection<string>(new[] { "abc", "cde", "1", "2", "3", "4", "5", "6", "7" });
        }

        private async void ExecuteSearchCommand()
        {
            //await Task.Delay(2000);

            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por {SearchTerm}?", "Sim", "Não");

            if (resposta)
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "Ok");
                Resultados.Clear();

                for (int i = 0; i < 30; i++)
                {
                    Resultados.Add($"Sim {i}");
                }
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "De nada", "Ok");
                Resultados.Clear();
            }
        }

        private bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
