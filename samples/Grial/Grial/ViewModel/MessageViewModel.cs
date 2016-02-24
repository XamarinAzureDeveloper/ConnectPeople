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
			Name = U.Name;
			FirstName = U.FirstName;
			NickName = U.NickName;
			Function = U.Function;
			Email = U.Email;
			Language = U.Language;
			Picture = U.Picture;

			UserItem CurrentUser = (UserItem)Application.Current.Properties ["User"];

			CurrentUserId = CurrentUser.Id;
			CurrentUserName = CurrentUser.Name;
			CurrentUserFirstName = CurrentUser.FirstName;
			CurrentUserNickName = CurrentUser.NickName;
			CurrentUserFunction = CurrentUser.Function;
			CurrentUserEmail = CurrentUser.Email;
			CurrentUserLanguage = CurrentUserLanguage;
			CurrentUserPicture = CurrentUser.Picture;


			//Messages = DBMessage.GetItems () as List<MessageItem>;
			//Messages = DBMessage.GetItems (currentUserId) as List<MessageItem>;
			Messages = (DBMessage.GetItems (CurrentUserId, InterlocutorId)) as List<MessageItem>;

		}



		//PROP INTERLOCUTOR (PERSONNE AVEC QUI JE VEUT DISCUTER)
		int interlocutorId;
		public int InterlocutorId {
			get{ return interlocutorId; }
			set{ SetProperty (ref interlocutorId, value); }
		}

		string name;
		public string Name {
			get{ return name; }
			set{ SetProperty (ref name, value); }
		}

		string firstName;
		public string FirstName {
			get{ return firstName; }
			set{ SetProperty (ref firstName, value); }
		}

		string nickName;
		public string NickName {
			get{ return nickName; }
			set{ SetProperty (ref nickName, value); }
		}

		string function;
		public string Function {
			get{ return function; }
			set{ SetProperty (ref function, value); }
		}

		string email;
		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		string language;
		public string Language {
			get{ return language; }
			set{ SetProperty (ref language, value); }
		}

		string picture;
		public string Picture {
			get { return picture; }
			set { SetProperty (ref picture, value); }
		}



		//PROP CURRENT USER (USER LOGUER SUR APPLICATION)

		int currentUserId;
		public int CurrentUserId {
			get{ return currentUserId; }
			set{ SetProperty (ref currentUserId, value); }
		}

		string currentUserName;
		public string CurrentUserName {
			get{ return currentUserName; }
			set{ SetProperty (ref currentUserName, value); }
		}

		string currentUserFirstName;
		public string CurrentUserFirstName {
			get{ return currentUserFirstName; }
			set{ SetProperty (ref currentUserFirstName, value); }
		}

		string currentUserNickName;
		public string CurrentUserNickName {
			get{ return currentUserNickName; }
			set{ SetProperty (ref currentUserNickName, value); }
		}

		string CurrentUserFunction;
		public string currentUserFunction {
			get{ return CurrentUserFunction; }
			set{ SetProperty (ref CurrentUserFunction, value); }
		}


		string currentUserEmail;
		public string CurrentUserEmail {
			get{ return currentUserEmail; }
			set{ SetProperty (ref currentUserEmail, value); }
		}

		string currentUserLanguage;
		public string CurrentUserLanguage {
			get{ return currentUserLanguage; }
			set{ SetProperty (ref currentUserLanguage, value); }
		}

		string currentUserPicture;
		public string CurrentUserPicture {
			get { return currentUserPicture; }
			set { SetProperty (ref currentUserPicture, value); }
		}


		//PROP MESSAGE

		List<MessageItem> messages;
		public List<MessageItem> Messages {
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

					//var DB = new MessageItemDatabase ();
					DBMessage.SaveItemToDB (Msg);

					Messages = (DBMessage.GetItems (currentUserId, InterlocutorId)) as List<MessageItem>;



				});
			}
		}

		public ICommand Translate {
			get {
				return new Command ( () => {
					
					TranslateService traduire = new TranslateService();
					traduire.TranslateAsync();

				});
			}
		}



	}
}

