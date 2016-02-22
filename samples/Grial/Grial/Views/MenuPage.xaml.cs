using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UXDivers.Artina.Grial
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();

		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as ViewModel;
			if (viewModel == null) 
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
		}
		async Task<bool> NavigateToViewModel (Type tViewModel, Func<object> viewModelFactory)
		{
			await Navigation.PushAsync ((Page)ViewFactory.Create (tViewModel, () => (ViewModel)viewModelFactory ()));
			Navigation.RemovePage (this);
			return true;
		}

	}
}

