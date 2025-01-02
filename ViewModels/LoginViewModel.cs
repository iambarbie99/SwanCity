using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SwanCity.Services;

namespace SwanCity.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AuthenticationService _authService;
        
        private string? _email;
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ResetPasswordCommand { get; }

        public LoginViewModel()
        {
            _authService = new AuthenticationService();
            
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
            ResetPasswordCommand = new Command(async () => await ResetPassword());
        }

        private async Task Login()
        {
            try
            {
                var token = await _authService.LoginUserAsync(Email, Password);
                await Shell.Current.GoToAsync("//AttractionsPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task Register()
        {
            try
            {
                var token = await _authService.RegisterUserAsync(Email, Password);
                await Shell.Current.DisplayAlert("Success", "Registration successful!", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task ResetPassword()
        {
            try
            {
                await _authService.ResetPasswordAsync(Email);
                await Shell.Current.DisplayAlert("Success", "Password reset email sent!", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
