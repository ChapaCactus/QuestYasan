//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class EnemyMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _Description;
		public int _Health;
		public int _Attack;
		public string _Sprite;
		public EnemyMasterRow(string __ID, string __Name, string __Description, string __Health, string __Attack, string __Sprite) 
		{
			_Name = __Name.Trim();
			_Description = __Description.Trim();
			{
			int res;
				if(int.TryParse(__Health, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Health = res;
				else
					Debug.LogError("Failed To Convert _Health string: "+ __Health +" to int");
			}
			{
			int res;
				if(int.TryParse(__Attack, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Attack = res;
				else
					Debug.LogError("Failed To Convert _Attack string: "+ __Attack +" to int");
			}
			_Sprite = __Sprite.Trim();
		}

		public int Length { get { return 5; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Name.ToString();
					break;
				case 1:
					ret = _Description.ToString();
					break;
				case 2:
					ret = _Health.ToString();
					break;
				case 3:
					ret = _Attack.ToString();
					break;
				case 4:
					ret = _Sprite.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Name":
					ret = _Name.ToString();
					break;
				case "Description":
					ret = _Description.ToString();
					break;
				case "Health":
					ret = _Health.ToString();
					break;
				case "Attack":
					ret = _Attack.ToString();
					break;
				case "Sprite":
					ret = _Sprite.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			ret += "{" + "Health" + " : " + _Health.ToString() + "} ";
			ret += "{" + "Attack" + " : " + _Attack.ToString() + "} ";
			ret += "{" + "Sprite" + " : " + _Sprite.ToString() + "} ";
			return ret;
		}
	}
	public sealed class EnemyMaster : IGoogle2uDB
	{
		public enum rowIds {
			Slime, Goblin, GoblinKing
		};
		public string [] rowNames = {
			"Slime", "Goblin", "GoblinKing"
		};
		public System.Collections.Generic.List<EnemyMasterRow> Rows = new System.Collections.Generic.List<EnemyMasterRow>();

		public static EnemyMaster Instance
		{
			get { return NestedEnemyMaster.instance; }
		}

		private class NestedEnemyMaster
		{
			static NestedEnemyMaster() { }
			internal static readonly EnemyMaster instance = new EnemyMaster();
		}

		private EnemyMaster()
		{
			Rows.Add( new EnemyMasterRow("Slime", "スライム", "スライムです", "10", "2", "CubicCactus"));
			Rows.Add( new EnemyMasterRow("Goblin", "ゴブリン", "ゴブリンです", "30", "5", "Spaceman128"));
			Rows.Add( new EnemyMasterRow("GoblinKing", "ゴブリン王", "ゴブリン王です", "100", "7", "Item001"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public EnemyMasterRow GetRow(rowIds in_RowID)
		{
			EnemyMasterRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public EnemyMasterRow GetRow(string in_RowString)
		{
			EnemyMasterRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
