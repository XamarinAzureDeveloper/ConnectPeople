using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class LoginViewModel : ViewModel
	{
		public LoginViewModel ()
		{
		}


		public ICommand LoginCommand 
		{ get { return new Command (() => { 

				Application.Current.MainPage = new MasterDetailPage {

					Master = new NavigationPage (ViewFactory.Create<MenuViewModel> () as Page){
						Title = "Master"
					},

					Detail = new NavigationPage (ViewFactory.Create<HomeViewModel> () as Page){
						Title = "Details"
					},
				};
			}
		); 
			} }
	}
}

