using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class ChatMessagesList : ContentPage
	{
		List<MessageItem> msg;

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

			msg = viewModel.Messages;

			viewModel.PropertyChanged += (sender, e) => {

				if (e.PropertyName == "Messages") {

					SetupChat (viewModel.Messages);

				}

			};

			SetupChat (viewModel.Messages);
		}

		public void SetupChat (List<MessageItem> messages)
		{
			//User FirstUser = SampleData.ChatMessagesList[0].From;
			View widget;

			if (msg == messages) {

				foreach (var message in messages) {
						widget = CompareId (message);
						widget.BindingContext = message;
						ChatMessagesListView.Children.Add (widget);
				}
			} else { 
				
				var message = messages.LastOrDefault ();
				widget = CompareId (message);
				widget.BindingContext = message;
				ChatMessagesListView.Children.Add (widget);
			}
			ScrollviewChat.ScrollToAsync (ChatMessagesListView, ScrollToPosition.End, true);

		}

		public View CompareId (MessageItem message)
		{
			if (message.IdSender == (int)((UserItem)Application.Current.Properties ["User"]).Id) {
				return new ChatLeftMessageItemTemplate ();
			} else {
				return new ChatRightMessageItemTemplate ();
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

