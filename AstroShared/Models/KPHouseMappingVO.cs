using System;
using System.Collections.Generic;

namespace AstroShared.Models
{
	public class KPHouseMappingVO
	{
		private short _house;

		private short _rashi;

		private short _laganrashi;

		private string _house_deg;

		private double _house_deg_decimal;

		private short _rashi_lord;

		private short _nak_lord;

		private short _sub_lord;

		private bool _is_manda;

		private List<KPSigniVO> _signi = new List<KPSigniVO>();

		private short _sub_sub_lord;

		public string DegreeHouse
		{
			get
			{
				return this._house_deg;
			}
			set
			{
				this._house_deg = value;
			}
		}

		public double DegreeHouse_Decimal
		{
			get
			{
				return this._house_deg_decimal;
			}
			set
			{
				this._house_deg_decimal = value;
			}
		}

		public short House
		{
			get
			{
				return this._house;
			}
			set
			{
				this._house = value;
			}
		}

		public bool Is_Manda
		{
			get
			{
				return this._is_manda;
			}
			set
			{
				this._is_manda = value;
			}
		}

		public short LaganRashi
		{
			get
			{
				return this._laganrashi;
			}
			set
			{
				this._laganrashi = value;
			}
		}

		public short Nak_Lord
		{
			get
			{
				return this._nak_lord;
			}
			set
			{
				this._nak_lord = value;
			}
		}

		public short Rashi
		{
			get
			{
				return this._rashi;
			}
			set
			{
				this._rashi = value;
			}
		}

		public short Rashi_Lord
		{
			get
			{
				return this._rashi_lord;
			}
			set
			{
				this._rashi_lord = value;
			}
		}

		public List<KPSigniVO> Signi
		{
			get
			{
				return this._signi;
			}
			set
			{
				this._signi = value;
			}
		}

		public short Sub_Lord
		{
			get
			{
				return this._sub_lord;
			}
			set
			{
				this._sub_lord = value;
			}
		}

		public short Sub_Sub_Lord
		{
			get
			{
				return this._sub_sub_lord;
			}
			set
			{
				this._sub_sub_lord = value;
			}
		}

		public KPHouseMappingVO()
		{
		}
	}
}