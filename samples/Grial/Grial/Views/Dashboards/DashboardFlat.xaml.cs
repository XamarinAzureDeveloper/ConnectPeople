using System;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class DashboardFlat : ContentPage
	{
		public DashboardFlat()
		{			
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}			
	}
}