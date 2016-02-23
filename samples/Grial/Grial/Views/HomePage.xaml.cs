using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UXDivers.Artina.Grial
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

//		protected override void OnBindingContextChanged ()
//		{
//			base.OnBindingContextChanged ();
//			var viewModel = BindingContext as ViewModel;
//			if (viewModel == null)
//				return;
//			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
//
//		}


		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as HomeViewModel;
			if (viewModel == null)
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			viewModel.NavigateBackDelegate = NavigateBack;
			this.ToolbarItems.Add (new ToolbarItem () { Icon = "logo.png",  Command = hideShowSearch });

		}


	

		public ICommand hideShowSearch {
			get {
				return new Command ( (M) => {
					if (StackSearch.IsVisible == true) {
						StackSearch.IsEnabled = false;
					} else {
						StackSearch.IsEnabled = true;
					};
				});
			}
		}





		async Task<bool> NavigateToViewModel (Type tViewModel, Func<object> viewModelFactory)
		{
			await Navigation.PushAsync ((Page)ViewFactory.Create (tViewModel, () => (ViewModel)viewModelFactory ()));
			//Navigation.RemovePage (this);
			return true;
		}

		public async Task<bool> NavigateBack ()
		{
			await Navigation.PopAsync ();			
			return true;
		}


		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}

		public void OnRefreshing (object sender, EventArgs e) {
			var listView = (sender as ListView);
			listView.EndRefresh();
		}

		public void animateIn( View uiElement ){
			animateItem (uiElement, 10500);
		}

		private void animateItem( View uiElement, uint duration ){
			uiElement.RotateYTo(99, duration, Easing.SinInOut);
		}

	}
}

