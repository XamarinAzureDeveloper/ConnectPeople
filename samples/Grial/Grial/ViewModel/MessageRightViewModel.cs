using System;

namespace UXDivers.Artina.Grial
{
	public class MessageRightViewModel : MessageItemViewModel
	{
		public MessageRightViewModel (MessageItem m)
		{
			ContentText = m.ContentText;
			ContentTranslate = m.ContentTranslate;
			IdSender = m.IdSender;
			IdRecipient = m.IdRecipient;
			CreateDate = m.CreateDate;
		}

		//PROP INTERLOCUTOR (PERSONNE AVEC QUI JE VEUT DISCUTER)
		int interlocutorId;
		public int InterlocutorId {
			get{ return interlocutorId; }
			set{ SetProperty (ref interlocutorId, value); }
		}

		string nickName;
		public string NickName {
			get{ return nickName; }
			set{ SetProperty (ref nickName, value); }
		}

		string picture;
		public string Picture {
			get { return picture; }
			set { SetProperty (ref picture, value); }
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

