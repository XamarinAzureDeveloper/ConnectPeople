using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public class MessageItemDatabase
	{
		SQLiteConnection database;

		public MessageItemDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<MessageItem> ();
		}

		public int SaveItemToDB (MessageItem Msg)
		{
			return database.Insert (Msg);
		}

//		public IEnumerable<MessageItem> GetItems (int currentUserId)
//		{
//			return (from i in database.Table<MessageItem>().Where (m => m.IdSender == currentUserId)
//				select i)?.ToList();
//		}


		public IEnumerable<MessageItem> GetItems (int currentUserId, int InterlocutorId)
		{
			var request = database.Table<MessageItem> ().Where (m => m.IdRecipient == currentUserId && m.IdSender == InterlocutorId 
				|| m.IdRecipient == InterlocutorId && m.IdSender == currentUserId).OrderBy(m => m.CreateDate).ToList();

			return request;

		}

		//		public UserItem GetItem (string email, string password)
		//		{
		//			return database.Table<UserItem> ().FirstOrDefault (a => a.Email == email && a.Password == password);
		//		}
	}
}

