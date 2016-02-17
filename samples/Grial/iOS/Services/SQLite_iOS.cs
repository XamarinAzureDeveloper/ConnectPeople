using System;
using SQLite;
using UXDivers.Artina.Grial;
using System.IO;


[assembly: Xamarin.Forms.Dependency (typeof(SQLite_iOS))]
namespace UXDivers.Artina.Grial
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "ConnectPeopleSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine (libraryPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection (path);
			// Return the database connection
			return conn;
		}

	}
}

