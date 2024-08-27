using SwitchPages.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwitchPages.ViewModels;

public class MainViewModel : BaseViewModel, INotifyPropertyChanged
{
    private BaseViewModel currentViewModel;
    public BaseViewModel CurrentViewModel 
    {
        get => currentViewModel;
        set
        {
            currentViewModel = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToAboutCommand { get; set; }
    public RelayCommand NavigateToHomeCommand { get; set; }

    public MainViewModel()
    {
        currentViewModel = new AboutViewModel();
        NavigateToAboutCommand = new(NavigateToAbout);
        NavigateToHomeCommand = new(NavigateToHome);
    }

    public void NavigateToAbout(object? obj)
    {
        CurrentViewModel = new AboutViewModel();
    }

    public void NavigateToHome(object? obj)
    {
        CurrentViewModel = new HomeViewModel();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}