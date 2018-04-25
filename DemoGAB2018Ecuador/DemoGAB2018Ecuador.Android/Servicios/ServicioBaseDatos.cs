using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using Java.IO;
using Xamarin.Forms;
using DemoGAB2018Ecuador.Droid.Servicios;
using DemoGAB2018Ecuador.Servicios;
using DemoGAB2018Ecuador.Helpers;

[assembly: Dependency(typeof(ServicioBaseDatosAndroid))]
namespace DemoGAB2018Ecuador.Droid.Servicios
{
    public class ServicioBaseDatosAndroid : IBaseDatos
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constantes.NombreBD);
        }
    }
}