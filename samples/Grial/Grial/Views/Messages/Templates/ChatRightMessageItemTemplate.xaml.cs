using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class ChatRightMessageItemTemplate : ContentView
	{
		public ChatRightMessageItemTemplate ()
		{
			InitializeComponent ();
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as MessageViewModel;
			if (viewModel == null)
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			viewModel.NavigateBackDelegate = NavigateBack;
			//this.ToolbarItems.Add (new ToolbarItem () { Icon = "logo.png",  Command =  hideShowSearch });
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

	}
}

