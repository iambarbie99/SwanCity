using SwanCity.Models;
using SwanCity.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace SwanCity.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly ProfileService _profileService;
        private readonly AuthenticationService _authService;
        private UserProfile? _profile;

        public ProfileViewModel()
        {
            _profileService = new ProfileService();
            _authService = new AuthenticationService();
            SaveProfileCommand = new Command(async () => await SaveProfileAsync());
        }

        public string FullName
        {
            get => _profile?.FullName ?? string.Empty;
            set
            {
                if (_profile != null)
                {
                    _profile.FullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _profile?.Email ?? string.Empty;
            set
            {
                if (_profile != null)
                {
                    _profile.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get => _profile?.PhoneNumber ?? string.Empty;
            set
            {
                if (_profile != null)
                {
                    _profile.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProfileImageUrl
        {
            get => _profile?.ProfileImageUrl ?? "default_profile.png";
            set
            {
                if (_profile != null)
                {
                    _profile.ProfileImageUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveProfileCommand { get; }

        public async Task LoadProfileAsync()
        {
            var userId = await _authService.GetCurrentUserIdAsync();
            if (userId != null)
            {
                _profile = await _profileService.GetProfileAsync(userId);
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));
                OnPropertyChanged(nameof(ProfileImageUrl));
            }
        }

        private async Task SaveProfileAsync()
        {
            if (_profile != null)
            {
                await _profileService.UpdateProfileAsync(_profile);
            }
        }
    }
}
