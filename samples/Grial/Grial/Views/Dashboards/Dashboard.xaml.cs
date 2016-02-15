using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class Dashboard : ContentPage
	{
		public Dashboard ()
		{			
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}
	}
}