using System;
using SQLite;

namespace UXDivers.Artina.Grial
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

