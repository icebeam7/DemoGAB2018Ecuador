using DemoGAB2018Ecuador.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoGAB2018Ecuador.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaBienvenido : ContentPage
	{
        Usuario usuario;

		public PaginaBienvenido (Usuario usuario)
		{
			InitializeComponent ();
            this.usuario = usuario;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            imagen.Source = ImageSource.FromFile(usuario.FotoActual);
            lblMensaje.Text = usuario.MensajeBienvenida;
        }
    }
}