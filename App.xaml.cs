using System.Diagnostics;

namespace SwanCity
{
    public partial class App : Application
    {
        private readonly IServiceProvider? _serviceProvider;

        public App()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Debug.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public App(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                // Log detailed information about the exception
                Debug.WriteLine("Exception in InitializeComponent:");
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            try
            {
                var appShell = _serviceProvider?.GetRequiredService<AppShell>() ?? throw new InvalidOperationException("Service provider is not initialized");
                return new Window(appShell)
                {
                    Title = "SwanCity"
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CreateWindow Exception: {ex}");
                Debug.WriteLine($"Inner Exception: {ex.InnerException}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
