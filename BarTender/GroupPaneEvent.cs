using System;

namespace BarTender
{
	/// <summary>
	/// Delegate for the events with <see cref="GroupPaneEventArgs"/>:
	/// </summary>
	public delegate void GroupPaneEventHandler(object sender, GroupPaneEventArgs eventArgs);

	/// <summary>
	/// Class with event data holding a <see cref="GroupPane"/>.
	/// </summary>
	public class GroupPaneEventArgs : EventArgs
	{
		#region Fields

		private GroupPane _groupPane;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="groupPane"><see cref="	GroupPane"/> associated with this event.</param>
		public GroupPaneEventArgs(GroupPane groupPane)
		{
			_groupPane = groupPane;
		}

		#endregion

		#region Public interface

		/// <summary>
		/// <see cref="	GroupPane"/> associated with this event.
		/// </summary>
		public GroupPane GroupPane
		{
			get { return _groupPane; }
		}

		#endregion
	}
}
