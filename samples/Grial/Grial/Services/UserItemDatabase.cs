using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace UXDivers.Artina.Grial
{
	public class UserItemDatabase
	{
		SQLiteConnection database;

		public UserItemDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<UserItem> ();
		}

		public int SaveItemToDB (UserItem User)
		{
			return database.Insert (User);
		}

		public int DeleteItemFromDB (UserItem User)
		{
			return database.Delete (User);
		}

		public IEnumerable<UserItem> GetItems ()
		{
			return (from i in database.Table<UserItem> ()
				select i)?.ToList();
		}

		public IEnumerable<UserItem>  GetItems (int id)
		{
			return database.Table<UserItem> ().Where (x => x.Id != id);
		}

		public UserItem GetItem (string email, string password)
		{
			return database.Table<UserItem> ().FirstOrDefault (a => a.Email == email && a.Password == password);
		}

//		public UserItem GetItem (int id)
//		{
//			return database.Table<UserItem> ().FirstOrDefault (a => a.Id == CurrentId);
//		}



	}
}

