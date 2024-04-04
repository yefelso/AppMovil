using System.Diagnostics;
using Xamarin.Forms;
using static MiPrimerMovil.App;

[assembly: Dependency(typeof(MiPrimerMovil.Droid.CloseAppImplementation))]

namespace MiPrimerMovil.Droid
{
    public class CloseAppImplementation : ICloseApp
    {
        public void Close()
        {
            // Cerrar la aplicación en Android
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
