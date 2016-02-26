using System;

namespace UXDivers.Artina.Grial
{
	public class MessageRightViewModel : MessageItemViewModel
	{


		public MessageRightViewModel (MessageItem m, UserItem U)
		{
			ContentText = m.ContentText;
			ContentTranslate = m.ContentTranslate;
			IdSender = m.IdSender;
			IdRecipient = m.IdRecipient;
			CreateDate = m.CreateDate;

			InterlocutorId = U.Id;
			NickName = U.NickName;
			Picture = U.Picture;
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
	}
}

