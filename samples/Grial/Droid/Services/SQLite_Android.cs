using System;
using SQLite;
using System.Runtime.CompilerServices;
using System.IO;
using UXDivers.Artina.Grial;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_Android))]
namespace UXDivers.Artina.Grial
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		public SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "ConnectPeopleSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection (path);
			// Return the database connection
			return conn;
		}
	}
}

