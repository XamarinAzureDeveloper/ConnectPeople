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

			UserItem CurrentUser = (UserItem)Application.Current.Properties ["User"];
			CurrentUserId = CurrentUser.Id;
			//Messages = DBMessage.GetItems () as List<MessageItem>;
			//Messages = DBMessage.GetItems (currentUserId) as List<MessageItem>;

			InitMessages ();

		}

		void InitMessages ()
		{
			var messageitems = (DBMessage.GetItems (CurrentUserId, InterlocutorId)) as List<MessageItem>;
			foreach (var messageItem in messageitems) {
				if (messageItem.IdSender == CurrentUserId)
				{ 	Messages.Add (new MessageLeftViewModel (messageItem));
				} else {
					Messages.Add (new MessageRightViewModel (messageItem));
				}

			}
		}

		//PROP INTERLOCUTOR (PERSONNE AVEC QUI JE VEUT DISCUTER)
		int interlocutorId;
		public int InterlocutorId {
			get{ return interlocutorId; }
			set{ SetProperty (ref interlocutorId, value); }
		}

		//PROP CURRENT USER (USER LOGUER SUR APPLICATION)

		int currentUserId;
		public int CurrentUserId {
			get{ return currentUserId; }
			set{ SetProperty (ref currentUserId, value); }
		}


		//PROP MESSAGE
	
		List<MessageItemViewModel> messages = new List<MessageItemViewModel>();
		public List<MessageItemViewModel> Messages {
			get{ return messages; }
			set{ SetProperty (ref messages, value); }
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

					DBMessage.SaveItemToDB (Msg);
					InitMessages();
					//Messages = (DBMessage.GetItems (currentUserId, InterlocutorId)) as List<MessageItem>;
				});
			}
		}

		public ICommand Translate {
			get {
				return new Command ( async (T) => {
					
					TranslateService traduire = new TranslateService();
					ContentTranslate = await traduire.TranslateAsync(ContentText);

					var Msg = new MessageItem {

						ContentText = ContentText,
						ContentTranslate = ContentTranslate,
						IdSender = CurrentUserId,
						IdRecipient = InterlocutorId,
						CreateDate = DateTime.Now.ToString (),
					};

					DBMessage.SaveItemToDB (Msg);

					InitMessages();

					//Messages = (DBMessage.GetItems (currentUserId, InterlocutorId)) as List<MessageItem>;


				});
			}
		}



	}
}

