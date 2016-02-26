using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace UXDivers.Artina.Grial
{
	public abstract class  MessageItemViewModel : ViewModel
	{
		//MessageItemDatabase DBMessage = new MessageItemDatabase ();
		public MessageItemViewModel ()
		{
		}
		public MessageItemViewModel (MessageItem m, UserItem U)
		{
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

