using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class MessageViewModel : ViewModel
	{
		public MessageViewModel ()
		{
		}

		UserItem UserSelected;

		public MessageViewModel (UserItem U)
		{
			UserSelected = U;
			Id = U.Id;
			Email = U.Email;

			UserItem CurrentUser = (UserItem) Application.Current.Properties["User"];
			CurrentUserEmail = CurrentUser.Email;
			CurrentUserId = CurrentUser.Id;
		}


		int id;
		public int Id {
			get{ return id; }
			set{ SetProperty (ref id, value); }
		}

		string email;
		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		int currentUserId;
		public int CurrentUserId {
			get{ return currentUserId; }
			set{ SetProperty (ref currentUserId, value); }
		}

		string currentUserEmail;
		public string CurrentUserEmail {
			get{ return currentUserEmail; }
			set{ SetProperty (ref currentUserEmail, value); }
		}
	}
}

