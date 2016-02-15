using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class DashboardWithImages : ContentPage
	{
		public DashboardWithImages ()
		{
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}
	}
}