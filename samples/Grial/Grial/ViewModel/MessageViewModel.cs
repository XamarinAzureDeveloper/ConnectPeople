using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

namespace UXDivers.Artina.Grial
{
	public class MessageViewModel : ViewModel
	{
		MessageItemDatabase DBMessage = new MessageItemDatabase ();

		public MessageViewModel ()
		{
		}

		public MessageViewModel (UserItem U)
		{
			//UserSelected = U;
			InterlocutorId = U.Id;
			Email = U.Email;


			UserItem CurrentUser = (UserItem)Application.Current.Properties ["User"];
			CurrentUserEmail = CurrentUser.Email;
			CurrentUserId = CurrentUser.Id;

			//Messages = DBMessage.GetItems () as List<MessageItem>;
			//Messages = DBMessage.GetItems (currentUserId) as List<MessageItem>;
			Messages = (DBMessage.GetItems (CurrentUserId, InterlocutorId)) as List<MessageItem>;

		}

		List<MessageItem> messages;
		public List<MessageItem> Messages {
			get{ return messages; }
			set{ SetProperty (ref messages, value); }
		}

		int interlocutorId;
		public int InterlocutorId {
			get{ return interlocutorId; }
			set{ SetProperty (ref interlocutorId, value); }
		}

		string email;
		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		int nickName;
		public int NickName {
			get{ return nickName; }
			set{ SetProperty (ref nickName, value); }
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


		string idSender;
		public string IdSender {
			get{ return idSender; }
			set{ SetProperty (ref idSender, value); }
		}


		string idRecipient;
		public string IdRecipient {
			get{ return idRecipient; }
			set{ SetProperty (ref idRecipient, value); }
		}

		string createDate;
		public string CreateDate {
			get{ return createDate; }
			set{ SetProperty (ref createDate, value); }
		}

		public ICommand SaveItem {
			get {
				return new Command ( (M) => {
					var Msg = new MessageItem {

						ContentText = ContentText,
						ContentTranslate = ContentTranslate,
						IdSender = CurrentUserId,
						IdRecipient = InterlocutorId,
						CreateDate = DateTime.Now.ToString (),
					};

					//var DB = new MessageItemDatabase ();
					DBMessage.SaveItemToDB (Msg);

					Messages = (DBMessage.GetItems (currentUserId, InterlocutorId)) as List<MessageItem>;


				});
			}
		}


	}
}

