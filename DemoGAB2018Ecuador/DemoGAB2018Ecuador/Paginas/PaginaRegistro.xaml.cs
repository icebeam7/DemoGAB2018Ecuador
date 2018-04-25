using DemoGAB2018Ecuador.Modelos;
using DemoGAB2018Ecuador.Servicios;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoGAB2018Ecuador.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaRegistro : ContentPage
	{
        MediaFile foto;

		public PaginaRegistro ()
		{
			InitializeComponent ();
		}

        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }

        async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                Loading(true);
                foto = await ServicioImagen.TomarFoto();

                if (foto != null)
                {
                    imagen.Source = ImageSource.FromStream(foto.GetStream);
                }
                else
                    await DisplayAlert("Error", "No se pudo tomar la fotografía.", "OK");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Loading(false);
            }
        }

        async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            bool op = false;

            try
            {
                Loading(true);
                var nombre = txtNombre.Text;
                var personID = await ServicioFace.RegistrarPersonaEnGrupo(nombre);
                var faceId = await ServicioFace.RegistrarRostro(personID, foto.GetStream());

                var usuario = new Usuario()
                {
                    Key = personID.ToString(),
                    Nombre = nombre,
                    EmocionActual = "",
                    FotoActual = "",
                    ScoreActual = 0
                };

                op = await new ServicioBaseDatos().RegistrarUsuario(usuario);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (op)
                {
                    await DisplayAlert("Correcto", "Empleado registrado correctamente", "OK");
                }
                else
                    await DisplayAlert("Error", "Error al registrar el empleado", "OK");

                Loading(false);
            }
        }
    }
}