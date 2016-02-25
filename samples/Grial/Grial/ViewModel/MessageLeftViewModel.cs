using System;
using Xamarin.Forms;
namespace UXDivers.Artina.Grial
{
	public class MessageLeftViewModel : MessageItemViewModel
	{
		public MessageLeftViewModel ( MessageItem m)
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

		//PROP MESSAGE
		string contentText;
		public string ContentText {
			get{ return contentText; }
			set{ SetProperty (ref contentText, value); }
		}

		string contentTranslate;
		public string ContentTranslate {
			get{ return contentTranslate; }
			set{ SetProperty (ref contentTranslate, value); }
		}

		int idSender;
		public int IdSender {
			get{ return idSender; }
			set{ SetProperty (ref idSender, value); }
		}

		int idRecipient;
		public int IdRecipient {
			get{ return idRecipient; }
			set{ SetProperty (ref idRecipient, value); }
		}

		string createDate;
		public string CreateDate {
			get{ return createDate; }
			set{ SetProperty (ref createDate, value); }
		}
	}
}

