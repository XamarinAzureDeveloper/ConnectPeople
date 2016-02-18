using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class MessagePage : ContentPage
	{
		MessageItemDatabase DBMessage = new MessageItemDatabase ();

		public MessagePage ()
		{
			InitializeComponent ();
			//listViewMessages.ItemsSource = DBMessage.GetItems ();

		}



		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as MessageViewModel;
			if (viewModel == null)
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			viewModel.NavigateBackDelegate = NavigateBack;


//			SetupChat(viewModel.Messages);


	
			//this.ToolbarItems.Add (new ToolbarItem () { Icon = "iconList.png", Command = viewModel.NavigateCommand });

		}



//
//	
//
//		public void SetupChat(List<MessageItem> messages){
//			var chatMessagesList = messages;
//
//			foreach (var message in messages) {
//				chatMessagesList.Add
//			}
//
//
//		User FirstUser = SampleData.ChatMessagesList[0].From;
//		View widget;
//
//		for (int index=0; index < chatMessagesList.Count; index++){
//
//			if ((chatMessagesList [index] as ChatMessage).From != FirstUser) {
//				widget = new ChatRightMessageItemTemplate ();
//			} else {
//				widget = new ChatLeftMessageItemTemplate ();
//			}
//			widget.BindingContext = chatMessagesList[index];
//			ChatMessagesListView.Children.Add( widget);
		//		} }
	




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







		public void OnMore (object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert ("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert ("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}

		public void OnItemTapped (object sender, EventArgs e)
		{
			var list = (sender as ListView);
			var selectedItem = list.SelectedItem;
			var userName = (selectedItem as Message).From.Name;
			DisplayAlert ("Message Tapped", "You tapped on " + userName + "'s message.", "OK");
			this.Navigation.PopModalAsync ();
		}

		public void OnRefreshing (object sender, EventArgs e)
		{
			var listView = (sender as ListView);
			listView.EndRefresh ();
		}

		public void animateIn (View uiElement)
		{
			animateItem (uiElement, 10500);
		}

		private void animateItem (View uiElement, uint duration)
		{
			uiElement.RotateYTo (99, duration, Easing.SinInOut);
		}
	}
}



