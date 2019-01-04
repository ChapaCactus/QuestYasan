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
	public class CardMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _Category;
		public int _Cost;
		public string _Sprite;
		public CardMasterRow(string __ID, string __Name, string __Category, string __Cost, string __Sprite) 
		{
			_Name = __Name.Trim();
			_Category = __Category.Trim();
			{
			int res;
				if(int.TryParse(__Cost, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Cost = res;
				else
					Debug.LogError("Failed To Convert _Cost string: "+ __Cost +" to int");
			}
			_Sprite = __Sprite.Trim();
		}

		public int Length { get { return 4; } }

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
					ret = _Category.ToString();
					break;
				case 2:
					ret = _Cost.ToString();
					break;
				case 3:
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
				case "Category":
					ret = _Category.ToString();
					break;
				case "Cost":
					ret = _Cost.ToString();
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
			ret += "{" + "Category" + " : " + _Category.ToString() + "} ";
			ret += "{" + "Cost" + " : " + _Cost.ToString() + "} ";
			ret += "{" + "Sprite" + " : " + _Sprite.ToString() + "} ";
			return ret;
		}
	}
	public sealed class CardMaster : IGoogle2uDB
	{
		public enum rowIds {
			Grassland, Goblin, GoblinKing
		};
		public string [] rowNames = {
			"Grassland", "Goblin", "GoblinKing"
		};
		public System.Collections.Generic.List<CardMasterRow> Rows = new System.Collections.Generic.List<CardMasterRow>();

		public static CardMaster Instance
		{
			get { return NestedCardMaster.instance; }
		}

		private class NestedCardMaster
		{
			static NestedCardMaster() { }
			internal static readonly CardMaster instance = new CardMaster();
		}

		private CardMaster()
		{
			Rows.Add( new CardMasterRow("Grassland", "草原", "Field", "3", "CubicCactus"));
			Rows.Add( new CardMasterRow("Goblin", "ゴブリン", "Enemy", "1", "Spaceman128"));
			Rows.Add( new CardMasterRow("GoblinKing", "ゴブリン王", "Boss", "2", "Item001"));
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
		public CardMasterRow GetRow(rowIds in_RowID)
		{
			CardMasterRow ret = null;
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
		public CardMasterRow GetRow(string in_RowString)
		{
			CardMasterRow ret = null;
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
