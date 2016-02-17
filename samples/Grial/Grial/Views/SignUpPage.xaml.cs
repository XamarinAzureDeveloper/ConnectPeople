using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as ViewModel;
			if (viewModel == null) 
				return;
			viewModel.NavigateBackDelegate = NavigateBack;
		}
		public async Task<bool> NavigateBack ()
		{
			await Navigation.PopAsync ();
			return true;
		}


	}
}

