using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class MenuViewModel : ViewModel
	{
		public MenuViewModel ()
		{
		}

		public ICommand LogoutCommand 
		{ get { return new Command ( (A) => { 

			Application.Current.MainPage = new NavigationPage (ViewFactory.Create<LoginViewModel> () as Page) {
				Title = "Login"
			};
		}); } }


	}
}

