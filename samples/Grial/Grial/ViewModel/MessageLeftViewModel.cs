using System;
using Xamarin.Forms;
namespace UXDivers.Artina.Grial
{
	public class MessageLeftViewModel : MessageItemViewModel
	{


		public MessageLeftViewModel (MessageItem m)
		{
			ContentText = m.ContentText;
			ContentTranslate = m.ContentTranslate;
			IdSender = m.IdSender;
			IdRecipient = m.IdRecipient;
			CreateDate = m.CreateDate;

			UserItem CurrentUser = (UserItem)Application.Current.Properties ["User"];
			CurrentUserId = CurrentUser.Id;
			CurrentUserNickName = CurrentUser.NickName;
			CurrentUserPicture = CurrentUser.Picture;

		}

		//PROP CURRENT USER (USER LOGUER SUR APPLICATION)
		int currentUserId;
		public int CurrentUserId {
			get{ return currentUserId; }
			set{ SetProperty (ref currentUserId, value); }
		}

		string currentUserNickName;
		public string CurrentUserNickName {
			get{ return currentUserNickName; }
			set{ SetProperty (ref currentUserNickName, value); }
		}


		string currentUserPicture;
		public string CurrentUserPicture {
			get { return currentUserPicture; }
			set { SetProperty (ref currentUserPicture, value); }
		}
	}
}

