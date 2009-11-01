using System;

namespace BarTender
{
	/// <summary>
	/// Delegate for the events with <see cref="GroupPaneCancelEventArgs"/>:
	/// </summary>
	public delegate void GroupPaneCancelEventHandler(object sender, GroupPaneCancelEventArgs eventArgs);

	/// <summary>
	/// Class with event data holding a <see cref="GroupPane"/> which can be cancelled.
	/// </summary>
	public class GroupPaneCancelEventArgs : GroupPaneEventArgs
	{
		#region Fields

		private bool _cancel;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="groupPane"><see cref="	GroupPane"/> associated with this event.</param>
		public GroupPaneCancelEventArgs(GroupPane groupPane) : base(groupPane)
		{
			_cancel = false;
		}

		#endregion

		#region Public interface

		/// <summary>
		/// Gets/sets whether the operation in process should be cancelled.
		/// </summary>
		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}

		#endregion
	}
}
