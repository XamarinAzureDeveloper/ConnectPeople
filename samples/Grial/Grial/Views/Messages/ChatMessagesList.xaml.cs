using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace UXDivers.Artina.Grial
{
	public partial class ChatMessagesList : ContentPage
	{
		ObservableCollection<MessageItemViewModel> msg;

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
			ToolbarItems.Add (new ToolbarItem () { Icon = "logo.png",  Command = hideShowTranslateMsg });

			msg = viewModel.Messages;
			viewModel.PropertyChanged += (sender, e) => {
				if (e.PropertyName == "Messages") {
					SetupChat (viewModel.Messages);
				}
			};

			SetupChat (viewModel.Messages);
		}

		public void SetupChat (ObservableCollection<MessageItemViewModel> messages)
		{
			View widget;
			if (msg == messages || msg == null) {

				foreach (var message in messages) {
					widget = CompareId (message);
					widget.BindingContext = message;
					ChatMessagesListView.Children.Add (widget);
				}
			} else if(msg.Count() < messages?.Count()){ 
				msg = messages;
				var message = messages.LastOrDefault ();
				widget = CompareId (message);
				widget.BindingContext = message;
				ChatMessagesListView.Children.Add (widget);
			}
			EntryWrite.Text = "";
			ScrollviewChat.ScrollToAsync (ChatMessagesListView, ScrollToPosition.End, true);
		}

		public View CompareId (MessageItemViewModel message)
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
			return true;
		}

		public async Task<bool> NavigateBack ()
		{
			await Navigation.PopAsync ();			
			return true;
		}

		public ICommand hideShowTranslateMsg {
			get {
				return new Command (() => {
					MessagingCenter.Send<Application> (Application.Current, "hideShowTranslate");
				});
			}
		}
	}
}