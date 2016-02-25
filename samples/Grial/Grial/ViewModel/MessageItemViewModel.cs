using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace UXDivers.Artina.Grial
{
	public class MessageItemViewModel : MessageViewModel
	{
		MessageItemDatabase DBMessage = new MessageItemDatabase ();

		public MessageItemViewModel ()
		{
		}

		public MessageItemViewModel (MessageItem m)
		{
			ContentText = m.ContentText;
			ContentTranslate = m.ContentTranslate;
			IdSender = m.IdSender;
			IdRecipient = m.IdRecipient;
			CreateDate = m.CreateDate;
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

