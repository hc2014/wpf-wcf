using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class SpreadLevelInfoModel
	{
        public SpreadLevelInfoModel()
		{}
		#region Model
		private long _id;
		private long _spreaditemid;
		private int _level;
		private int _experience;
		private decimal _rebate;
        private bool _enable = false;
        private string _describe;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        public bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long SpreadItemID
		{
			set{ _spreaditemid=value;}
			get{return _spreaditemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Experience
		{
			set{ _experience=value;}
			get{return _experience;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Rebate
		{
			set{ _rebate=value;}
			get{return _rebate;}
		}
		#endregion Model

	}
}

