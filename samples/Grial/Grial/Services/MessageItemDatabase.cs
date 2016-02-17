using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

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

		public IEnumerable<MessageItem> GetItems ()
		{
			return (from i in database.Table<MessageItem> ()
				select i)?.ToList();
		}

//		public UserItem GetItem (string email, string password)
//		{
//			return database.Table<UserItem> ().FirstOrDefault (a => a.Email == email && a.Password == password);
//		}
	}
}

