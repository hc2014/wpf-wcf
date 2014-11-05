using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class SpreadItemModel
	{
        public SpreadItemModel()
		{}
		#region Model
		private long _id;
		private long? _spreaditemid=null;
		private string _name;
		private int _parentquantity=0;
		private bool _enable= false;
        private int _parentLevel = 0;
        private long _priductid;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}


        public long ProductID
        {
            set { _priductid = value; }
            get { return _priductid; }
        }

        public int ParentLevel
        {
            set { _parentLevel = value; }
            get { return _parentLevel; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long? SpreadItemID
		{
			set{ _spreaditemid=value;}
			get{return _spreaditemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentQuantity
		{
			set{ _parentquantity=value;}
			get{return _parentquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		#endregion Model

	}
}

