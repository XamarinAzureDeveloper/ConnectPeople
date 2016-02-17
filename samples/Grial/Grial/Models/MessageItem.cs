using System;
using SQLite;

namespace UXDivers.Artina.Grial
{
	public class MessageItem
	{
		[PrimaryKey, AutoIncrement, Column("id")]
		public int Id { get; set; }

		//		[MaxLength(50), Column("Name")]
		public string ContentText { get; set; }

		//		[MaxLength(50), Column("FirstName")]
		public string ContentTranslate { get; set; }

		//		[MaxLength(50), Column("NickName")]
		public int IdSender {get; set; }

		//		[MaxLength(50), Column("Function")]
		public int IdRecipient { get; set; }

		//		[MaxLength(50), Column("Email")]
		public string CreateDate { get; set; }

	}
}

