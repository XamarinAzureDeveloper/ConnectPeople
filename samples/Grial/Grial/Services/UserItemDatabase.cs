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
			//database.CreateTable<MessageItem> ();
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
			return database.Table<UserItem> ().Where (x => x.Id != id );
		}

		public UserItem GetItem (string email, string password)
		{
			return database.Table<UserItem> ().FirstOrDefault (a => a.Email == email && a.Password == password);
		}




		public IEnumerable<UserItem>  GetItems (int id, int idsender, int idRecever)
		{
			return database.Table<UserItem> ().Where (x => x.Id == idsender || x.Id == idRecever);
		}


		public IEnumerable<MessageItem> GetMsg (int currentUserId, int InterlocutorId)
		{
			var request = database.Table<MessageItem> ().Where (m => m.IdRecipient == currentUserId && m.IdSender == InterlocutorId 
				|| m.IdRecipient == InterlocutorId && m.IdSender == currentUserId).OrderBy(m => m.CreateDate).ToList();

			return request;

		}


//		public IEnumerable<UserItem> GetItemsInMsg (int currentUserId)
//		{
//			return (from i in database.Table<MessageItem>().Where (i => i.IdSender == currentUserId || i.IdRecipient == currentUserId)
//				select i)?.ToList().Distinct(m=> m.i);
//		}


//		public void Compare (int id, int idsender, int idRecever)
//		{
//			var result = from U in UserItem join M in MessageItem on 
//				((U.Id == M.idsender) equals U.Id ) || 
//				((U.Id == M.idRecever)  equals U.id) select U);
//		}






		public IEnumerable<UserItem>  SearchItems (string search)
		{
			return database.Table<UserItem> ().Where (x => x.Name == search ||
				x.FirstName == search||
				x.NickName == search ||
				x.Email == search).ToList();
		}



//
//
//
//		Messages = (DBMessage.GetItems (CurrentUserId, InterlocutorId)) as List<MessageItem>;


//		public UserItem GetItem (int id)
//		{
//			return database.Table<UserItem> ().FirstOrDefault (a => a.Id == CurrentId);
//		}



	}
}

