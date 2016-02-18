using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class ChatMessagesList : ContentPage
	{
		public ChatMessagesList ()
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

			viewModel.PropertyChanged += (sender, e) => {

				if (e.PropertyName == "Messages") 
				{
					SetupChat(viewModel.Messages);
				}

			};



	

		

		}

		public void SetupChat(List<MessageItem> messages){


			//User FirstUser = SampleData.ChatMessagesList[0].From;
			View widget;

			foreach (var message in messages) {

				if (message.IdSender == (int)((UserItem) Application.Current.Properties["User"]).Id ) {
					widget = new ChatLeftMessageItemTemplate ();
				} else {
					widget = new ChatRightMessageItemTemplate ();
				}

				widget.BindingContext = message;
				ChatMessagesListView.Children.Add( widget);

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

	}
}

