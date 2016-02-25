using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UXDivers.Artina.Grial
{
	public partial class ChatLeftMessageItemTemplate : ContentView
	{
		public ChatLeftMessageItemTemplate ()
		{
			InitializeComponent ();
			MessagingCenter.Subscribe<Application> (Application.Current, "hideShowTranslate", async (sender) => {
				await ShowLabelTranslate ();
			});
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as MessageLeftViewModel;
			if (viewModel == null)
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			viewModel.NavigateBackDelegate = NavigateBack;
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

		async Task ShowLabelTranslate ()
		{
			if (labelTranslate.IsVisible == true) {
				labelTranslate.IsVisible = false;
			} else {
				labelTranslate.IsVisible = true;
			};
		}
	}
}

