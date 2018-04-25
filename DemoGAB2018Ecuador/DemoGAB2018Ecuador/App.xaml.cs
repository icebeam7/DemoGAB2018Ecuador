using Xamarin.Forms;

namespace DemoGAB2018Ecuador
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Paginas.PaginaLogin());
		}
	}
}
